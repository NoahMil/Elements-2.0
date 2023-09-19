using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouvelle Epreuve")]
public class Epreuve : ScriptableObject
{
    public string nom;
    public bool epreuveCompleted = false ;
    public GameObject totem;
    public GameObject portal;
    public GameObject destroyedportal;

}

