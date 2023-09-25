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
        if (initialArrow != null)
        {
            MeshRenderer renderer = initialArrow.GetComponent<MeshRenderer>();
            VisualEffect visualEffect = initialArrow.GetComponent<VisualEffect>();
            if (renderer != null)
            {
                renderer.enabled = false;
                visualEffect.enabled = false;
            }
        }

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
