using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartMenuTextManager : MonoBehaviour
{
    private TextMeshProUGUI textComponent = null;

    private Gameplay gameplayScript = null;

    void Start()
    {
        textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        gameplayScript = GameObject.FindGameObjectWithTag("Gameplay Manager").GetComponent<Gameplay>();


        textComponent.text = CreateText();
    }

    private string CreateText()
    {
        string min = gameplayScript.minGuess.ToString();
        string max = gameplayScript.maxGuess.ToString();

        return "Think of a number between " + min + " and " + max;
    }
}
