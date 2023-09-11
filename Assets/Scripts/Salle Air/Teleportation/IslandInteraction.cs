using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IslandInteraction : XRBaseInteractable
{
    private Material islandMaterial;
    private Color originalColor;
    private Color highlightColor = Color.yellow; // Couleur de surbrillance lorsque survolée.

    protected override void Awake()
    {
        base.Awake();
        islandMaterial = GetComponent<Renderer>().material;
        originalColor = islandMaterial.color;
    }

    public void SetHighlightColor(Color newColor)
    {
        islandMaterial.color = newColor;
    }

    public void ResetColor()
    {
        islandMaterial.color = originalColor;
    }
}
