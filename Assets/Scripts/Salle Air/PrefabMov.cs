using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMov : MonoBehaviour
{
    public float rotationSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
