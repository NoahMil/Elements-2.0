using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ArrowDestruction : MonoBehaviour
{
    private float delayDestruction = 5f;
    void Start()
    {
        Collider collider = GetComponent<Collider>();
        if (collider !=null)
        {
            collider.isTrigger = false;
        }
        Destroy(gameObject, delayDestruction);
    }
}
