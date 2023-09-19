using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float descentSpeed = 1.0f;
    public float rotationSpeed;
    private float startTime;

    [SerializeField] public AudioSource mysteriousSE;

    void Start()
    {
        startTime = Time.time;
        AudioSource.PlayClipAtPoint(mysteriousSE.clip, transform.position);

    }

    void Update()
    {
        float distanceCovered = (Time.time - startTime) * descentSpeed;
        float journeyFraction = distanceCovered / Vector3.Distance(startPoint, endPoint);
        transform.position = Vector3.Lerp(startPoint, endPoint, journeyFraction);

        if (journeyFraction >= 1.0f)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }


}
