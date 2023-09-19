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

    public float InputThreshold = 1.0f;
    public Transform playerTransform;
    public TeleportWaypoint[] waypoints;
    private int currentIndex = 0;
    private bool canTeleport = true; // Peut téléporter dès le début
    private bool canScroll = true; // Peut faire défiler dès le début
    private float teleportCooldown = 1.0f; // Temps de recharge entre les téléportations
    private float scrollCooldown = 1.0f; // Temps de recharge entre les défilements

    private void Start()
    {
    }

    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource1), inputButton1, out bool TeleportationPressed, InputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton21, out bool ScrollUp, InputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton22, out bool ScrollDown, InputThreshold);

        if (TeleportationPressed && canTeleport)
        {
            StartCoroutine(TeleportCooldown());
            canTeleport = false; // Désactive la possibilité de téléporter

            waypoints[currentIndex].TeleportPlayer(playerTransform);
            foreach (TeleportWaypoint waypoint in waypoints)
            {
                waypoint.SetSelected(false);
            }
        }

        if (ScrollUp && canScroll)
        {
            StartCoroutine(ScrollCooldown());
            canScroll = false; // Désactive la possibilité de faire défiler

            ScrollWaypoints(1);
        }

        if (ScrollDown && canScroll)
        {
            StartCoroutine(ScrollCooldown());
            canScroll = false; // Désactive la possibilité de faire défiler

            ScrollWaypoints(-1);
        }
    }

    void ScrollWaypoints(int direction)
    {
        waypoints[currentIndex].SetSelected(false);
        currentIndex = (currentIndex + direction + waypoints.Length) % waypoints.Length;        
        waypoints[currentIndex].SetSelected(true);
    }

    IEnumerator TeleportCooldown()
    {
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true; // Réactive la possibilité de téléporter
    }

    IEnumerator ScrollCooldown()
    {
        yield return new WaitForSeconds(scrollCooldown);
        canScroll = true; // Réactive la possibilité de faire défiler
    }
}


