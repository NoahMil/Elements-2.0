using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControllerInput : MonoBehaviour
{
    public XRNode inputSource1;
    public XRNode inputSource2;

    public InputHelpers.Button inputButton1;
    public InputHelpers.Button inputButton2;
    public InputHelpers.Button inputButton3;

    public float InputThreshold = 0.1f;
    public Transform playerTransform;
    public TeleportWaypoint[] waypoints;
    private int currentIndex = 0;

    private bool canTeleport = true;
    private bool hasScrolled = false;


    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource1), inputButton1, out bool TeleportationPressed,
            InputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton2, out bool ScrollDown,
            InputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton3, out bool ScrollUp,
            InputThreshold);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hasScrolled)
            {
                waypoints[currentIndex].TeleportPlayer(playerTransform);
                foreach (TeleportWaypoint waypoint in waypoints)
                {
                    waypoint.SetSelected(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            hasScrolled = true;
            ScrollWaypoints(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            hasScrolled = true;
            ScrollWaypoints(-1);
        }
    }

    void ScrollWaypoints(int direction)
    {
        waypoints[currentIndex].SetSelected(false);
        currentIndex = (currentIndex + direction + waypoints.Length) % waypoints.Length;
        waypoints[currentIndex].SetSelected(true);
    }
}



