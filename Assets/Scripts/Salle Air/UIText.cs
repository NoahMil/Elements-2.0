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

    private int currentIndex = 0;
    private float timer = 0f;

    private void Start()
    {
        textOptions = new string[]
        {
            "Bienvenue Aventurier !",
            "Pour cette épreuve, tu devras abattre toutes les cibles présentes dans cette salle",
            "Saisis l'arc en face de toi et l'épreuve commencera! Bonne chance!"
        };

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
    }
}


