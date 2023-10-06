using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanUI : MonoBehaviour
{
    public VRControllerInput vrControllerInput; // Référence à votre script VRControllerInput
    public Button[] waypointButtons; // Tableau de boutons représentant les waypoints

    private void Start()
    {
        // Assigner des fonctions de rappel pour les boutons
        for (int i = 0; i < waypointButtons.Length; i++)
        {
            int index = i; // Capturer la valeur de i pour chaque bouton
            waypointButtons[i].onClick.AddListener(() => OnWaypointButtonClick(index));
        }
    }

     public void OnWaypointButtonClick(int index)
    {
        vrControllerInput.SelectWaypoint(index); // Appeler la méthode de sélection de waypoint dans VRControllerInput
    }
}
