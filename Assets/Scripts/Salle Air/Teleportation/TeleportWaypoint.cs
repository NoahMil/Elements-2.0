using UnityEngine;

public class TeleportWaypoint : MonoBehaviour
{
    public Material normalMaterial;
    public Material selectedMaterial;
    private Renderer waypointRenderer;
    private bool isSelected = false;
    public GameObject objectPrefab; // Référence au préfab à instancier
    public float prefabHeight = 2.0f; // Hauteur du préfab au-dessus du waypoint
    public Vector3 prefabRotation; // Rotation à appliquer au préfab
    public GameObject spawnPositionPlayer;
    private GameObject spawnedPrefab; // Référence à l'objet instancié
    public AudioSource teleportSE;

    void Start()
    {
        waypointRenderer = GetComponent<Renderer>();
        waypointRenderer.material = normalMaterial;
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
        waypointRenderer.material = selected ? selectedMaterial : normalMaterial;

        if(selected && objectPrefab != null)
        {
            Vector3 spawnPosition = transform.position + Vector3.up * prefabHeight;
            spawnedPrefab = Instantiate(objectPrefab, spawnPosition, Quaternion.Euler(prefabRotation));
        }
        else
        {
            if(spawnedPrefab != null)
            {
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



