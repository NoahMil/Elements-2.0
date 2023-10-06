using System;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWaypoint : MonoBehaviour
{
    public Material normalMaterial;
    public VRControllerInput _vrControllerInput;
    public Material selectedMaterial;
    private Renderer waypointRenderer;
    private bool isSelected;
    public GameObject pointer;
    public float prefabHeight = 2.0f;
    public Vector3 prefabRotation;
    public GameObject spawnPositionPlayer;
    private GameObject spawnedPrefab;
    public AudioSource teleportSE;
    public GameObject[] islandSelectedPlan;
    public int test;


    void Start()
    {
        waypointRenderer = GetComponent<Renderer>();
        waypointRenderer.material = normalMaterial;
    }
    
    public void Selected(int index)
    {
        SetSelected(true, index);
        test = index;
    }
    
    
    
    public void SetSelected(bool selected, int index)
    {
        isSelected = selected;
        waypointRenderer.material = selected ? selectedMaterial : normalMaterial;
        if (selected && pointer != null && islandSelectedPlan[index] != null)
        {
            pointer.SetActive(true);
            islandSelectedPlan[index].SetActive(true);
        }

        else
        {
            if (pointer != null && islandSelectedPlan[index] != null)
            {
                pointer.SetActive(false);
                islandSelectedPlan[index].SetActive(false); 
            } 
        }
    }

    public void TeleportPlayer(Transform playerTransform)
    {
        teleportSE.Play();
        playerTransform.position = spawnPositionPlayer.transform.position;
        playerTransform.rotation = spawnPositionPlayer.transform.rotation;
    }
}



