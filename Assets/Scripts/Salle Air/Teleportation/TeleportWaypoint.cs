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
    public GameObject objectPrefab;
    public float prefabHeight = 2.0f;
    public Vector3 prefabRotation;
    public GameObject spawnPositionPlayer;
    private GameObject spawnedPrefab;
    public AudioSource teleportSE;
    public GameObject[] islandSelectedPlan;


    void Start()
    {
        waypointRenderer = GetComponent<Renderer>();
        waypointRenderer.material = normalMaterial;
    }
    
    
    public void SetSelected(bool selected, int index)
    {
        isSelected = selected;
        waypointRenderer.material = selected ? selectedMaterial : normalMaterial;
        if (selected && objectPrefab != null && islandSelectedPlan[index] != null)
        {
            Vector3 spawnPosition = transform.position + Vector3.up * prefabHeight;
            spawnedPrefab = Instantiate(objectPrefab, spawnPosition, Quaternion.Euler(prefabRotation));
            islandSelectedPlan[index].SetActive(true);
        }

        else
        {
            if (spawnedPrefab != null && islandSelectedPlan[index] != null)
            {
                islandSelectedPlan[index].SetActive(false);
                Destroy(spawnedPrefab);
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



