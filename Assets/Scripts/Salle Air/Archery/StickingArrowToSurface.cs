using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.VFX;

public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private SphereCollider myCollider;

    [SerializeField] private GameObject stickingArrow;
    
    public GameObject initialArrow;
    
    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;
        Transform childTransform = transform.GetChild(0);
        Destroy(childTransform.gameObject);
        
        GameObject arrow = Instantiate(stickingArrow);
        arrow.transform.position = transform.position;
        arrow.transform.forward = transform.forward;

        if (collision.collider.attachedRigidbody != null)
        {
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;
        }
        collision.collider.GetComponent<IHittable>()?.GetHit();
    }
    
}
