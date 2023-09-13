using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class ScoreArchery : MonoBehaviour
{
    [SerializeField] private Epreuve AirScriptable;
    [SerializeField] private ListeTarget _listeTarget;
    public TextMeshProUGUI ScoreText;
    public int score = 0;
    
    private void OnEnable()
    {
        MovingTarget.OnCheckArchery += CheckArchery;

    }
    private void OnDisable()
    {
        MovingTarget.OnCheckArchery -= CheckArchery;
    }

    private void Start()
    {
        score = 0;
    }

    public void UpdateScore()
    {
        ScoreText.text = "Cibles : " + score + "/3";
    }

    private void Update()
    {
        UpdateScore();
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
