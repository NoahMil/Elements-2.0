using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWaypoint : MonoBehaviour
{
    public bool IsTargeted { get; private set; }
    public Material normalMaterial;
    public Material targetedMaterial;
    private Renderer waypointRenderer;

    void Start()
    {
        waypointRenderer = GetComponent<Renderer>();
        waypointRenderer.material = normalMaterial;
    }

    public void SetTargeted(bool targeted)
    {
        IsTargeted = targeted;
        waypointRenderer.material = targeted ? targetedMaterial : normalMaterial;
    }

    public void TeleportPlayer(Transform playerTransform)
    {
        Vector3 teleportPosition = transform.position + Vector3.up * 2;
        playerTransform.position = teleportPosition;
    }
}

