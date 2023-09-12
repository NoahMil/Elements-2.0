using UnityEngine;

public class TeleportWaypoint : MonoBehaviour
{
    public Material normalMaterial;
    public Material selectedMaterial;
    private Renderer waypointRenderer;
    public float zPositionVariable;
    private bool isSelected = false;

    void Start()
    {
        waypointRenderer = GetComponent<Renderer>();
        waypointRenderer.material = normalMaterial;
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
        waypointRenderer.material = selected ? selectedMaterial : normalMaterial;
    }

    public void TeleportPlayer(Transform playerTransform)
    {
        playerTransform.position  = new Vector3(transform.position.x, transform.position.y, transform.position.z +zPositionVariable);
    }
}

