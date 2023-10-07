using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocherRotation : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public Transform targetObject;
    public float floatHeight = 0.5f;       
    public float floatSpeed = 0.5f;
    public float selfRotationSpeed = 0.5f; 
    private Vector3 initialPosition;
    private float floatingY;
 void Start()
    {
        initialPosition = transform.position;
        floatingY = initialPosition.y;
    }    

 void Update()
 {
      // Calculez la nouvelle position en fonction du temps.
     float newY = floatingY + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
 
      // Appliquez la nouvelle position à l'objet.
     transform.position = new Vector3(transform.position.x, newY, transform.position.z);    
     transform.Rotate(Vector3.up * selfRotationSpeed * Time.deltaTime);
     //transform.RotateAround(targetObject.position, Vector3.up, rotationSpeed * Time.deltaTime);;//
 }
   
}