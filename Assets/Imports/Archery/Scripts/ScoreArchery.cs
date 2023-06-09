using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ScoreArchery : MonoBehaviour
{
    [SerializeField] private Epreuve AirScriptable;
    [SerializeField] private ListeTarget _listeTarget;
    
    private void OnEnable()
    {
        MovingTarget.OnCheckArchery += CheckArchery;

    }
    private void OnDisable()
    {
        MovingTarget.OnCheckArchery -= CheckArchery;

    }

    private void CheckArchery()
    {
        foreach (Target target in _listeTarget.Targets)
        {
            if (target.targetCompleted)
            {
                AirScriptable.epreuveCompleted = true;
                Debug.Log("Complete");
            }
        }

    }
}
