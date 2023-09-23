using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Island")]
public class Island : ScriptableObject
{
    public List<Target> targets;
    public bool islandComplete;

    public bool AreAllTargetsDestroyed()
    {
        foreach (Target target in targets)
        {
            if (!target.targetDestroyed)
            {
                return false;
            }
        }
        
        return true;
    }
    
}