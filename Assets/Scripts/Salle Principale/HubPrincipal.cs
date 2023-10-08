using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPrincipal : MonoBehaviour
{
    [SerializeField] private ListeEpreuve _listeEpreuve;
    [SerializeField] private GameObject finalEscaliers;

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
                finalEscaliers.SetActive(true);
                epreuves.totem.SetActive(true);
       //         epreuves.destroyedPortal.SetActive(true);
                epreuves.vfxPortal.SetActive(false);
                epreuves.portal.SetActive(false);
            }
        }
    }
}

