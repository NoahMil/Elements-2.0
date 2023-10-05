using UnityEngine;
using UnityEngine.UI;

public class IslandButton : MonoBehaviour
{
    public int islandIndex; // L'index de l'île associée à ce bouton
    public TeleportWaypoint teleportWaypoint; // Référence au script TeleportWaypoint

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnIslandButtonClick);
    }

   public void OnIslandButtonClick()
    {
        // Appeler la fonction SetSelected de TeleportWaypoint avec l'index de l'île
        teleportWaypoint.SetSelected(true, islandIndex);
    }
}

