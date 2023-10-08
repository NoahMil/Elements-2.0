using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TeleportWaypoint : MonoBehaviour
{
    public Material normalMaterial;
    public Material selectedMaterial;
    private Renderer waypointRenderer;
    private bool isSelected;
    public GameObject pointer;
    public GameObject spawnPositionPlayer;
    public GameObject spawnPositionUI;
    private GameObject spawnedPrefab;
    public GameObject[] islandSelectedPlan;
    public Sprite uiImage; 


    void Start()
    {
        waypointRenderer = GetComponent<Renderer>();
        waypointRenderer.material = normalMaterial;
    }
    
    public void SetSelected(bool selected, int index)
    {
        if (selected)
        {
            for (int i = 0; i < islandSelectedPlan.Length; i++)
            {
                if (i != index && islandSelectedPlan[i] != null)
                {
                    islandSelectedPlan[i].SetActive(false);
                }
            }
        }

        isSelected = selected;
        waypointRenderer.material = selected ? selectedMaterial : normalMaterial;

        if (selected && pointer != null && islandSelectedPlan != null && index >= 0 && index < islandSelectedPlan.Length)
        {
            pointer.SetActive(true);
            islandSelectedPlan[index].SetActive(true);
        }
        else
        {
            if (pointer != null && islandSelectedPlan != null && index >= 0 && index < islandSelectedPlan.Length)
            {
                pointer.SetActive(false);
                islandSelectedPlan[index].SetActive(false);
            }
        }
    }

    public void TeleportPlayer(Transform playerTransform)
    {
        playerTransform.position = spawnPositionPlayer.transform.position;
        playerTransform.rotation = spawnPositionPlayer.transform.rotation;
    }

    public void TeleportUI(RectTransform uiTransform)
    {
        uiTransform.position = spawnPositionUI.transform.position;
        uiTransform.rotation = spawnPositionUI.transform.rotation;
        uiTransform.GetComponent<Image>().sprite = uiImage;
    }
}


