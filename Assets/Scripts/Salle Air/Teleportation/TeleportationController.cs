using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
/*
public class TeleportationController : MonoBehaviour
{
    private XRController xrController; // Le contrôleur VR que vous utilisez (main gauche/droite).

    private void Start()
    {
        xrController = GetComponent<XRController>();
        xrController.onSelectEnter.AddListener(Teleport); // Utilisez l'événement onSelectEnter.
    }

    private void Teleport(SelectEnterEventArgs args)
    {
        XRBaseInteractable interactable = args.interactable;

        if (interactable != null)
        {
            // Changez la couleur de l'île sélectionnée en surbrillance.
            IslandInteraction island = interactable.GetComponent<IslandInteraction>();

            if (island != null)
            {
                island.SetHighlightColor(Color.green); // Couleur de surbrillance lors de la sélection.
            }

            // Obtenez la position de l'île flottante à laquelle vous souhaitez vous téléporter.
            Vector3 targetPosition = interactable.transform.position;

            // Déplacez le contrôleur VR (au lieu du joueur) vers la nouvelle position.
            xrController.transform.position = targetPosition;

            // Réinitialisez la couleur de toutes les autres îles.
            ResetIslandColors();
        }
    }

    private void ResetIslandColors()
    {
        // Réinitialisez la couleur de toutes les îles.
        IslandInteraction[] allIslands = FindObjectsOfType<IslandInteraction>();

        foreach (IslandInteraction island in allIslands)
        {
            island.ResetColor();
        }
    }
}
*/

