using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IslandsUI : MonoBehaviour
{
    public List<Island> _listIsland;
    public TextMeshProUGUI ScoreTextUI;
    
    public void Start()
    {
        ScoreTextUI.text = "Ile complétée : " + "/7";
    }
}
