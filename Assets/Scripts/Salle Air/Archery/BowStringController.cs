using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringController : MonoBehaviour
{
    [SerializeField] private BowString bowStringRenderer;

    private XRGrabInteractable interactable;

    [SerializeField] private Transform midPointGrabObject, midPointVisualObject, midPointParent;

    [SerializeField] private float bowStringStretchLimit = 0.3f;

    private Transform interactor;

    private float strength, previousStrength;

    [SerializeField] private float stringSoundThreshold = 0.001f;

    [SerializeField] private AudioSource audioSource;

    public UnityEvent OnBowPulled;
    public UnityEvent<float> OnBowReleased;
    
    private bool onFloor = false;
    private float onFloorDelay = 0f;


    private void Awake()
    {
        interactable = midPointGrabObject.GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        interactable.selectEntered.AddListener(PrepareBowString);
        interactable.selectExited.AddListener(ResetBowString);
    }

    private void ResetBowString(SelectExitEventArgs arg0)
    {
        OnBowReleased?.Invoke(strength);
        strength = 0;
        previousStrength = 0;
        audioSource.pitch = 1;
        audioSource.Stop();
        
        interactor = null;
        midPointGrabObject.localPosition = Vector3.zero;
        midPointVisualObject.localPosition = Vector3.zero;
        bowStringRenderer.CreateString(null);

    }

    private void PrepareBowString(SelectEnterEventArgs arg0)
    {
        interactor = arg0.interactorObject.transform;
        OnBowPulled?.Invoke();
    }

    private void Update()
    {
        if (interactor != null)
        {
            Vector3 midPointLocalSpace = 
                midPointParent.InverseTransformPoint(midPointGrabObject.position); 

            float midPointLocalZAbs = Mathf.Abs(midPointLocalSpace.z);

            previousStrength = strength;
            HandleStringPushedBackToStart(midPointLocalSpace);

            HandleStringPulledBackTolimit(midPointLocalZAbs, midPointLocalSpace);

            HandlePullingString(midPointLocalZAbs, midPointLocalSpace);

            bowStringRenderer.CreateString(midPointVisualObject.position);
        }
        
        if (onFloor)
        {
            onFloorDelay += Time.deltaTime;

            if (onFloorDelay >= 10f)
            {
                Destroy(gameObject);
            }
        }
    }
    
    
    private void HandlePullingString(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs < bowStringStretchLimit)
        {
            if (audioSource.isPlaying == false && strength <= 0.01f)
            {
                audioSource.Play();
            }
            strength = Remap(midPointLocalZAbs, 0, bowStringStretchLimit, 0, 1);
            midPointVisualObject.localPosition = new Vector3(0, 0, midPointLocalSpace.z);

            PlayStringPullingSound();
        }
    }

    private void PlayStringPullingSound()
    {
        if (Math.Abs(strength - previousStrength) > stringSoundThreshold)
        {
            if (strength < previousStrength)
            {
                audioSource.pitch = -1;
            }

            else
            {
                audioSource.pitch = 1;
            }
            audioSource.UnPause();
        }

        else
        {
            audioSource.Pause();
        }
    }

    private float Remap(float value, int fromMin, float fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    private void HandleStringPulledBackTolimit(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs >= bowStringStretchLimit)
        {
            audioSource.Pause();
            strength = 1;
            midPointVisualObject.localPosition = new Vector3(0, 0, -bowStringStretchLimit);
        }
    }

    private void HandleStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z >= 0)
        {
            audioSource.pitch = 1;
            audioSource.Stop();
            strength = 0;
            midPointVisualObject.localPosition = Vector3.zero;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
        
        if (collision.gameObject.CompareTag("Void"))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = false;
            onFloorDelay = 0f;
        }
    }

    void HandDetection()
    {
        
    }

}