using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private GameObject midPointVisual, arrowPrefab,arrowSpawnPoint, leftarrowSpawnPoint;

    public VRControllerInput _vrControllerInput;

    [SerializeField]
    private float arrowMaxSpeed = 10;

    [SerializeField] private AudioSource bowReleaseAudioSource;


    public void PrepareArrow()
    {
        midPointVisual.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        bowReleaseAudioSource.Play();
        midPointVisual.SetActive(false);

        if (_vrControllerInput.isLeftHanded == true)
        {
            GameObject arrow = Instantiate(arrowPrefab);
            arrow.transform.position = leftarrowSpawnPoint.transform.position;
            arrow.transform.rotation = midPointVisual.transform.rotation;
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.AddForce(midPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);

        }
        
        else
        {
            GameObject arrow = Instantiate(arrowPrefab);
            arrow.transform.position = arrowSpawnPoint.transform.position;
            arrow.transform.rotation = midPointVisual.transform.rotation;
            Rigidbody rb = arrow.GetComponent<Rigidbody>();
            rb.AddForce(midPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);   
        }

    }
}
