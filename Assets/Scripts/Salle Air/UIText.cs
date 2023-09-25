using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] textOptions;
    public float changeInterval;
    [SerializeField] private Transform player;

    private int currentIndex = 0;
    private float timer = 0f;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = textOptions[currentIndex];
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeInterval)
        {
            currentIndex = (currentIndex + 1) % textOptions.Length;
            textComponent.text = textOptions[currentIndex];
            timer = 0f;
        }

        Vector3 playerPosition = player.position;
        Vector3 lookAtPosition = new Vector3(playerPosition.x, transform.position.y + 180f, playerPosition.z);
        transform.LookAt(lookAtPosition);
    }
}
