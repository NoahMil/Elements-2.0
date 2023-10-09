using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPrincipal : MonoBehaviour
{
    [SerializeField] private ListeEpreuve _listeEpreuve;
    [SerializeField] private GameObject finalEscaliers;
    [SerializeField] private GameObject totem;
    [SerializeField] private GameObject destroyedPortal;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject VFXPortal;


    private void Start()
    {
        CheckEpreuves();
        
        foreach (Epreuve epreuves in _listeEpreuve.Epreuves)
        {
            { 
                finalEscaliers.SetActive(false);
                totem.SetActive(false);
                destroyedPortal.SetActive(false);
                portal.SetActive(true);
                VFXPortal.SetActive(true);

                /*
                epreuves.totem.SetActive(false);
                epreuves.destroyedPortal.SetActive(false);
                epreuves.vfxPortal.SetActive(true);
                epreuves.portal.SetActive(true);
                */
            }
        }
    }
    
    public void CheckEpreuves()
    {
        foreach (Epreuve epreuves in _listeEpreuve.Epreuves)
        {
            if (epreuves.epreuveCompleted)
            { 
                finalEscaliers.SetActive(true);
                totem.SetActive(true);
                destroyedPortal.SetActive(true);
                portal.SetActive(true);
                VFXPortal.SetActive(false);
                /*
                epreuves.totem.SetActive(true);
               epreuves.destroyedPortal.SetActive(true);
               epreuves.vfxPortal.SetActive(false);
                epreuves.portal.SetActive(false);
                */
            }
        }
    }
}

