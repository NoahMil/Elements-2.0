using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;



public class ArrowController : MonoBehaviour
{
    [SerializeField] private GameObject rightmidPointVisual,
        leftmidPointVisual,
        arrowPrefab,
        rightarrowSpawnPoint,
        leftarrowSpawnPoint;

    private bool isRightHanded;

    [SerializeField] private float arrowMaxSpeed = 10;

    [SerializeField] private AudioSource bowReleaseAudioSource;
    public float InputThreshold = 1.0f;

    public XRNode inputSource2;

    public InputHelpers.Button inputButton23;

    public Collider bowHandleCollider;
    public bool maindroiteArc;


    public void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton23, out bool rightHand,
            InputThreshold);
        isRightHanded = rightHand;
    }

    
    public void PrepareArrow()
    {
        if (maindroiteArc)
        {
            leftmidPointVisual.SetActive(true);
            rightmidPointVisual.SetActive(false);
        }
        else
        {
            rightmidPointVisual.SetActive(true);
            leftmidPointVisual.SetActive(false);
        }
    }

    public void ReleaseArrow(float strength)
    {
        if (maindroiteArc)
        {
            bowReleaseAudioSource.Play();
            leftmidPointVisual.SetActive(false);
            GameObject arrow = Instantiate(arrowPrefab);
            arrow.transform.position = leftarrowSpawnPoint.transform.position;
            arrow.transform.rotation = leftmidPointVisual.transform.rotation;
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.AddForce(leftmidPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);
        }
        else
        {
            bowReleaseAudioSource.Play();
            rightmidPointVisual.SetActive(false);
            GameObject arrow = Instantiate(arrowPrefab);
            arrow.transform.position = rightarrowSpawnPoint.transform.position;
            arrow.transform.rotation = rightmidPointVisual.transform.rotation;
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.AddForce(rightmidPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Controller") && isRightHanded)
        {
            maindroiteArc = true;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Controller") && isRightHanded)
        {
            maindroiteArc = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            maindroiteArc = false;
        }
    }
}



