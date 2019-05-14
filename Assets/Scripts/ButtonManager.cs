using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ButtonManager : MonoBehaviour
{
        
    private AudioManager audioManagerScript = null;

    Gameplay gamePlayScript = null;

    SceneLoader sceneLoaderScript = null;

    PeonVoiceManager peonVoiceManager = null;

    void Start()
    {
        gamePlayScript = GameObject.FindGameObjectWithTag("Gameplay Manager").GetComponent<Gameplay>();
        sceneLoaderScript = GameObject.FindGameObjectWithTag("Scene Loader").GetComponent<SceneLoader>();
        audioManagerScript = GameObject.FindGameObjectWithTag("Audio Manager").GetComponent<AudioManager>();
        peonVoiceManager = GameObject.FindGameObjectWithTag("Peon").GetComponentInChildren<PeonVoiceManager>();
    }


    public void PlayerSaysHigher()
    {
        peonVoiceManager.NeedToGuessHigher();
        gamePlayScript.PlayerSaidHigher();
    }

    public void PlayerSaysCorrect()
    {
        audioManagerScript.GuessedRight();
        gamePlayScript.PlayerSaidCorrect();
    }

    public void PlayerSaysLower()
    {
        peonVoiceManager.NeedToGuessLower();
        gamePlayScript.PlayerSaidLower();
    }

    public void Exit()
    {
        StartCoroutine("actuallyExit");
    }

    private IEnumerator actuallyExit()
    {
        yield return new WaitForSeconds(peonVoiceManager.ExitGame());

        // Remove me for builds, add me for editing
        // EditorApplication.isPlaying = false;

        // Add me for builds, remove me for editing
        Application.Quit();
    }

    public void BeginGame()
    {
        audioManagerScript.BeginGame();
        sceneLoaderScript.LoadNextScene();
    }

    public void PlayAgain()
    {
        audioManagerScript.RestartGame();
        sceneLoaderScript.LoadStartScene();
        gamePlayScript.FreshStart();
    }

}
