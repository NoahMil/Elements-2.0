using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestruction : MonoBehaviour
{
    private float delayDestruction = 4f;
    void Start()
    {
        Destroy(gameObject, delayDestruction);
    }
}
