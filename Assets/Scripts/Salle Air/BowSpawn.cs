using System;
using UnityEngine;
using UnityEngine.XR;


public class BowSpawn : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    private GameObject spawnedObject;
    private Rigidbody rb;

    void Start()
    {
        SpawnObject();
        rb = spawnedObject.GetComponent<Rigidbody>();
    }

    void SpawnObject()
    {
        spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
    }

    public void Update()
    {
        if (spawnedObject == null)
        {
            RespawnObject();
        }
    }

    void RespawnObject()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
        spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        rb.isKinematic = true;
        rb.useGravity = false;

    }
    
}