using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControllerInput : MonoBehaviour
{
    public XRNode inputSource1;
    public XRNode inputSource2;
    
    public InputHelpers.Button inputButton21;
    public InputHelpers.Button inputButton22;
    public InputHelpers.Button inputButton23;
    
    public float InputThreshold = 1.0f;
    public Transform playerTransform;
    public RectTransform uiTransform;
    public TeleportWaypoint[] waypoints;
    private TeleportWaypoint lastSelectedWaypoint = null;


    public int currentIndex;
    private bool canTeleport = true;
    private bool canScroll = true;
    float teleportCooldown = 1.0f;
    private float scrollCooldown = 1.0f;
    private GameObject islandPlan;
    public AudioSource teleportSE;
    
    public bool IsTeleporting { get; private set; }


    private void Start()
    {
        currentIndex = 0;
        lastSelectedWaypoint = null;

    }

    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton21, out bool ScrollUp, InputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton22, out bool ScrollDown, InputThreshold);
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource2), inputButton23, out bool TeleportationPressed, InputThreshold);



        if (TeleportationPressed && canTeleport)
        {
            StartCoroutine(TeleportCooldown());
            canTeleport = false;
            teleportSE.Play();
            waypoints[currentIndex].TeleportUI(uiTransform);
            waypoints[currentIndex].TeleportPlayer(playerTransform);
            foreach (TeleportWaypoint waypoint in waypoints)
            {
                waypoint.SetSelected(false, currentIndex);
            }
            
            if (!IsTeleporting) 
            {
                SelectWaypoint(currentIndex);
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
        IsTeleporting = true; 
        yield return new WaitForSeconds(teleportCooldown);
        IsTeleporting = false; 
        canTeleport = true; 
    }

    IEnumerator ScrollCooldown()
    {
        yield return new WaitForSeconds(scrollCooldown);
        canScroll = true;
    }

    public void SelectWaypoint(int index)
    {
        if (lastSelectedWaypoint != null)
        {
            lastSelectedWaypoint.SetSelected(false, currentIndex);
        }
        currentIndex = index;

        if (waypoints != null)
        {
            foreach (TeleportWaypoint waypoint in waypoints)
            {
                if (waypoint != null)
                {
                    waypoint.SetSelected(false, currentIndex);
                }
            }

            if (currentIndex >= 0 && currentIndex < waypoints.Length && waypoints[currentIndex] != null)
            {
                waypoints[currentIndex].SetSelected(true, currentIndex);
                lastSelectedWaypoint = waypoints[currentIndex];
            }
        }
        canTeleport = true;
    }
}

