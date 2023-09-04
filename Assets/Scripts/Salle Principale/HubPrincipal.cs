using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPrincipal : MonoBehaviour
{
    [SerializeField] private ListeEpreuve _listeEpreuve;
    private void Start()
    {
        CheckEpreuves();
    }
    
    public void CheckEpreuves()
    {
        foreach (Epreuve epreuves in _listeEpreuve.Epreuves)
        {
            if (epreuves.epreuveCompleted)
            {
                epreuves.totem.SetActive(true);
            }
        }
    }
}

