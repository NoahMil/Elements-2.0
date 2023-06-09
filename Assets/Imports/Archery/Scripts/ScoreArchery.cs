using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ScoreArchery : MonoBehaviour
{
    public HubPrincipal hubPrincipal;
    public Epreuve AirScriptable;

    
    public void Won()
    {
        AirScriptable.epreuveCompleted = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        AirScriptable.epreuveCompleted = true;
        Debug.Log("Complete");
    }
}
