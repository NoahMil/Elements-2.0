using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouveau Waypoint")]
public class Waypoint : ScriptableObject
{
    public bool selected;
    public Material materialSelected;
    public Material material;
}