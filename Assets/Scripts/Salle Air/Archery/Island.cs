using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


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
                targetscore++;
                ScoreTextUI.text = targetscore + "/" + targetNb;
                return false;
            }
        }
        return true;
    }
    
}