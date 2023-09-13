using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleporteRay : MonoBehaviour
{
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;


    void Update()
    {
        leftTeleportation.SetActive(leftActivate.action.ReadValue<UnityEngine.Vector2>().y > 0.1F);
        rightTeleportation.SetActive(rightActivate.action.ReadValue<UnityEngine.Vector2>().y > 0.1F);
    }
}
