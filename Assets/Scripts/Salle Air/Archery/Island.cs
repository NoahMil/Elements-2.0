using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;


[CreateAssetMenu(fileName = "Island")]
public class Island : ScriptableObject
{
    public List<Target> targets;
    public bool islandComplete;
    public TextMeshProUGUI ScoreTextUI;
    public int targetscore;
    public int targetNb;


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