using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField]
    public int minGuess = 1;
    [SerializeField]
    public int maxGuess = 1000;

    //[HideInInspector]
    public int currentMinGuess = 0;
    //[HideInInspector]
    public int currentMaxGuess = 0;
    //[HideInInspector]
    public int currentGuess = 0;

    SceneLoader sceneLoaderScript = null;

    void Start()
    {
        sceneLoaderScript = GameObject.FindGameObjectWithTag("Scene Loader").GetComponent<SceneLoader>();

        FreshStart();
    }
    
    public void FreshStart()
    {
        currentMaxGuess = maxGuess;
        currentMinGuess = minGuess;

        Guess();
    }

    public void Guess()
    {
        // 7-Guess: The mathematically fastest way to get the right guess. Also good for troubleshooting mix/max settings, since it's first guess is exactly in between max and min
        //currentGuess = (Mathf.FloorToInt((currentMaxGuess + currentMinGuess) / 2));

        // Completely random: The preferred orcish method. Max is increased by 1 to account for Random.Range's exclusive top-bound
        currentGuess = Random.Range(currentMinGuess, currentMaxGuess+1);

    }

    public void PlayerSaidHigher()
    {
        currentMinGuess = currentGuess + 1;

        Guess();
    }

    public void PlayerSaidCorrect()
    {
        sceneLoaderScript.LoadNextScene();
    }

    public void PlayerSaidLower()
    {
        currentMaxGuess = currentGuess - 1;

        Guess();
    }


}
