using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControllerInput : MonoBehaviour
{
    public XRNode inputSource1;
    public XRNode inputSource2;

    public InputHelpers.Button inputButton11;
    public InputHelpers.Button inputButton12;

    
    public InputHelpers.Button inputButton21;
    public InputHelpers.Button inputButton22;
    public InputHelpers.Button inputButton23;

    public float InputThreshold = 1.0f;
    public Transform playerTransform;
    public TeleportWaypoint[] waypoints;

    public int currentIndex;
    private bool canTeleport = true; 
    private bool canScroll = true;  
    float teleportCooldown = 1.0f; 
    private float scrollCooldown = 1.0f;

    private void Start()
    {
        currentIndex = 0;
    }

    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource1), inputButton11, out bool TeleportationPressed, InputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton21, out bool ScrollUp, InputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton22, out bool ScrollDown, InputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource1), inputButton12, out bool RightHand, InputThreshold);

        
        if (TeleportationPressed && canTeleport)
        {
            StartCoroutine(TeleportCooldown());
            canTeleport = false;
            waypoints[currentIndex].TeleportPlayer(playerTransform);
            foreach (TeleportWaypoint waypoint in waypoints)
            {
                waypoint.SetSelected(false, currentIndex);
                waypoint.islandPlan.SetActive(true);
                if (TeleportationPressed && canTeleport)
                {
                    waypoint.islandPlan.SetActive(false);
                }
            }
        }

        if (ScrollUp && canScroll)
        {
            StartCoroutine(ScrollCooldown());
            canScroll = false; 

            ScrollWaypoints(1);
        }

        if (ScrollDown && canScroll)
        {
            StartCoroutine(ScrollCooldown());
            canScroll = false; 

            ScrollWaypoints(-1);
        }
    }

    void ScrollWaypoints(int direction)
    {
        waypoints[currentIndex].SetSelected(false, currentIndex);
        currentIndex = (currentIndex + direction + waypoints.Length) % waypoints.Length;
        waypoints[currentIndex].SetSelected(true, currentIndex);

    }

    IEnumerator TeleportCooldown()
    {
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true; 
    }

    IEnumerator ScrollCooldown()
    {
        yield return new WaitForSeconds(scrollCooldown);
        canScroll = true; 
    }
}


