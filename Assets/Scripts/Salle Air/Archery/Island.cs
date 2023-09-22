using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Island")]
public class Island : ScriptableObject
{
    public Target[] targets;
    public bool islandCompleted = false ;
}
