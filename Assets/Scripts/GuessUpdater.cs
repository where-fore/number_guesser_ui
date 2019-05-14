using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessUpdater : MonoBehaviour
{
    Gameplay gameplayScript = null;

    TextMeshProUGUI guessTextComponent = null;

    private string displayedGuess = "";
    private string currentGuess = "";

    public int guesses = 0;


    void Start()
    {
        gameplayScript = GameObject.FindGameObjectWithTag("Gameplay Manager").GetComponent<Gameplay>();
        guessTextComponent = gameObject.GetComponentInParent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
    }

    void Update()
    {
        currentGuess = gameplayScript.currentGuess.ToString();
        if (displayedGuess != currentGuess)
        {
            UpdateText(currentGuess);
        }
    }

    private void UpdateText(string guessToUpdateTo)
    {
        guessTextComponent.text = ("" + guessToUpdateTo + "?");
        displayedGuess = currentGuess;

        if (guesses > 0)
        {
            gameObject.GetComponentInParent<ExclamationAnimation>().FlashSprite();
        }

        guesses ++;
    }

}
