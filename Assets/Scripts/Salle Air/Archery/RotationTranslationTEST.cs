using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTranslationTEST : MonoBehaviour
{
    public float RotationSpeed = 20.0f;
    
    
    public Transform startMarker;
    public Transform endMarker;
    // Movement speed in units per second.
    public float speed = 1.0F;
    // Time when the movement started.
    private float startTime;
    // Total distance between the markers.
    private float journeyLength;

    private Transform swap;

    private void Start()
    {
        // Keep a note of the time the movement started.
            startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.Rotate(
            Vector3.right *RotationSpeed *Time.deltaTime +
            Vector3.forward *RotationSpeed *Time.deltaTime,
            Space.Self
        );*/
        
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;
        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        //StartCoroutine("Forth", fractionOfJourney);
        
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, time);
    }
    
    
}
