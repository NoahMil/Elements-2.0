using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControllerInput : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float InputThreshold = 0.1f;
    public float snapDistance = 2.0f; // Distance à laquelle le raycast "snape" automatiquement au waypoint

    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isTeleportEnabled, InputThreshold);
        
        if (isTeleportEnabled)
        {
            RaycastHit hit;
            Vector3 raycastDirection = transform.forward;

            if (Physics.Raycast(transform.position, raycastDirection, out hit))
            {
                TeleportWaypoint waypoint = hit.collider.GetComponent<TeleportWaypoint>();
                float distanceToWaypoint = Vector3.Distance(transform.position, hit.point);

                if (waypoint != null && waypoint.IsTargeted && distanceToWaypoint < snapDistance)
                {
                    raycastDirection = (waypoint.transform.position - transform.position).normalized;
                }

                if (Physics.Raycast(transform.position, raycastDirection, out hit))
                {
                    waypoint.TeleportPlayer(transform);
                }
            }
        }
    }
}

