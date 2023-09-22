using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireEpreuve : MonoBehaviour
{
    public GameObject arc;
    public GameObject[] cibles; 
    public float delaiAvantApparition = 2f;

    
    // private void Start()
    // {
    //     foreach (Target target in _listeTarget.Targets)
    //     {
    //         target.gameObject.SetActive(false);
    //     }
    // }
    //
    // private void Update()
    // {
    //     if (!epreuveDemarree && arcEstSaisi())
    //     {
    //         epreuveDemarree = true;
    //         StartCoroutine(LancerEpreuve());
    //     }
    // }
    //
    // private bool arcEstSaisi()
    // {
    //     return false; 
    // }
    //
    // private IEnumerator LancerEpreuve()
    // {
    //     yield return new WaitForSeconds(delaiAvantApparition);
    //
    //     foreach (Target target in _listeTarget.Targets)
    //     {
    //         target.gameObject.SetActive(true);        }
    // }
}


