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
    [SerializeField] private GameObject startMenu;
    public TextMeshProUGUI ScoreText;
    public GameObject totemReward;
    public int score = 0;
    
    private void OnEnable()
    {
        FloatingTarget.OnCheckArchery += CheckArchery;

    }
    private void OnDisable()
    {
        FloatingTarget.OnCheckArchery -= CheckArchery;
    }

    private void Start()
    {
        score = 0;
    }

    public void UpdateScore()
    {
        ScoreText.text = "Cibles : " + score + "/7";
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
                totemReward.SetActive(true);
                startMenu.SetActive(false);
                Debug.Log("Complete");
            }
        }

    }
}
