using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndMenuTextManager : MonoBehaviour
{
    private TextMeshProUGUI textComponent = null;

    void Start()
    {
        textComponent = gameObject.GetComponent<TextMeshProUGUI>();

        textComponent.text = CreateText();
    }

    private string CreateText()
    {
        return "Thanks for playing!";
    }

}
