using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Destroy(transform.parent.gameObject, delayDestruction);
    }
}
