using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControllerInput : MonoBehaviour
{
    public XRNode inputSource1;
    public XRNode inputSource2;

    public InputHelpers.Button inputButton1;
    public InputHelpers.Button inputButton21;
    public InputHelpers.Button inputButton22;

    private float InputThreshold = 1.0f;
    public Transform playerTransform;
    public TeleportWaypoint[] waypoints;
    private int currentIndex = 0;
    private bool canTeleport = false;
    private bool canScroll = false;

    private void Start()
    {
        canScroll = true;
    }


    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource1), inputButton1, out bool TeleportationPressed, InputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton21, out bool ScrollUp, InputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton22, out bool ScrollDown, InputThreshold);

        if (TeleportationPressed && canTeleport)
        {
            waypoints[currentIndex].TeleportPlayer(playerTransform);
            foreach (TeleportWaypoint waypoint in waypoints)
            {
                waypoint.SetSelected(false);
            }
        }
        

        if (ScrollUp &&  canScroll)
        {
            canTeleport = true;
            ScrollWaypoints(1);
        }

        if (ScrollDown && canScroll)
        {
            canTeleport = true;
            ScrollWaypoints(-1);
        }
        Debug.Log("TeleportationPressed: " + TeleportationPressed);
        Debug.Log("ScrollUp: " + ScrollUp);
        Debug.Log("ScrollDown: " + ScrollDown);
    }

    void ScrollWaypoints(int direction)
    {
        waypoints[currentIndex].SetSelected(false);
        currentIndex = (currentIndex + direction + waypoints.Length) % waypoints.Length;
        waypoints[currentIndex].SetSelected(true);
        canScroll = false;
        StartCoroutine(TeleportCooldown());
        canScroll = true;
    }

    IEnumerator TeleportCooldown()
    {
        Debug.Log("Cooldown started");
        yield return new WaitForSeconds(5f);
        Debug.Log("Cooldown finished");    }
}


