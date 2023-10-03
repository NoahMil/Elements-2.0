using System.Collections.Generic;
using UnityEngine;

public class TeleportWaypoint : MonoBehaviour
{
    public Material normalMaterial;
    public VRControllerInput _vrControllerInput;
    public Material selectedMaterial;
    private Renderer waypointRenderer;
    private bool isSelected = false;
    public GameObject objectPrefab; 
    public float prefabHeight = 2.0f; 
    public Vector3 prefabRotation; 
    public GameObject spawnPositionPlayer;
    private GameObject spawnedPrefab; 
    public AudioSource teleportSE;
    public GameObject[] islandSelectedPlan;
    private GameObject islandSelectedPlanFinal;
    private GameObject spawnedPlan; 


    void Start()
    {
        waypointRenderer = GetComponent<Renderer>();
        waypointRenderer.material = normalMaterial;
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
        waypointRenderer.material = selected ? selectedMaterial : normalMaterial;

        if(selected && objectPrefab != null && islandSelectedPlan != null)
        {
            Vector3 spawnPosition = transform.position + Vector3.up * prefabHeight;
            spawnedPrefab = Instantiate(objectPrefab, spawnPosition, Quaternion.Euler(prefabRotation));
            islandSelectedPlanFinal = Instantiate(islandSelectedPlan[_vrControllerInput.currentIndex]);
        }
        else
        {
            if(spawnedPrefab != null && islandSelectedPlanFinal !=null)
            {
                Destroy(islandSelectedPlanFinal);
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



