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
    [SerializeField] private List<Island> _islandsList;
    [SerializeField] private TextMeshProUGUI[] _islandsListGUI;
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
        foreach (Island island in _islandsList)
        {
            island.targetscore = 0;
            island.islandComplete = false;
        }
        
    }

    public void UpdateScore()
    {
        ScoreText.text = "Ile complétée : " + score + "/7";
      
        foreach (Island island in _islandsList)
        {
            island.ScoreTextUI.text = island.targetscore + "/" + island.targetNb;
        }
        
        for (int i = 0; i <= 6; i++)
        {
            _islandsListGUI[i].text = _islandsList[i].ScoreTextUI.text;
        }
        
    }
    

    private void Update()
    {
        UpdateScore();
    }

    public bool AreAllIslandsComplete()
    {
        foreach (Island island in _islandsList)
        {
            if (!island.islandComplete)
            {
                return false;
            }
        }
        return true;

    }

    private void CheckArchery()
    {
        foreach (Island island in _islandsList)
        {
            foreach (Target target in island.targets)
            {
                if (target.targetDestroyed && !target.targetCounted)
                {
                    island.targetscore++;
                    target.targetCounted = true;
                    if (island.AreAllTargetsDestroyed() && !island.islandComplete)
                    {
                        island.islandComplete = true;
                        score++;
                    }
                    
                    if (AreAllIslandsComplete())
                    {
                        AirScriptable.epreuveCompleted = true;
                        totemReward.SetActive(true);
                        startMenu.SetActive(false);
                    }
                }
            }
        }
    }
}
    
    
