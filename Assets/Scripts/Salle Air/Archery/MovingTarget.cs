using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingTarget : MonoBehaviour, IHittable
{
    private Rigidbody rb;
    private bool stopped = false;

    private Vector3 nextposition;
    private Vector3 originPosition;
    
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float arriveThreshold, movementRadius = 2, speed = 1;
    
    [SerializeField] private Target _target;
    
    public delegate void ArcheryEvents();

    public static event ArcheryEvents OnCheckArchery;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originPosition = transform.position;
        nextposition = GetNewMovementPosition();
    }

    private Vector3 GetNewMovementPosition()
    {
        return originPosition + (Vector3)Random.insideUnitCircle * movementRadius;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((rb.isKinematic || collision.gameObject.CompareTag("Arrow")) == false)
        {
            audioSource.Play();
        }
    }
    
    public void GetHit()
    {
        _target.hp--;
        if(_target.hp <= 0)
        {
            rb.isKinematic = false;
            stopped = true;
            _target.targetCompleted = true;
            OnCheckArchery?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if (stopped == false)
        {
            if(Vector3.Distance(transform.position,nextposition) < arriveThreshold)
            {
                nextposition = GetNewMovementPosition();
            }

            Vector3 direction = nextposition - transform.position;
            rb.MovePosition(transform.position + direction.normalized * Time.fixedDeltaTime * speed);
        }
    }
    
    
}


