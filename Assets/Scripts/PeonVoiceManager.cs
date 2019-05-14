using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeonVoiceManager : MonoBehaviour
{
    AudioSource audioSourceComponent = null;

    [SerializeField]
    private AudioClip[] needToGuessAgain = null;

    [SerializeField]
    private AudioClip[] exitGame = null;

    [SerializeField]
    private AudioClip[] annoyed0 = null;

    [SerializeField]
    private AudioClip[] annoyed1 = null;

    [SerializeField]
    private AudioClip[] annoyed2 = null;

    private int annoyed = 0;

    private int pressed = 0;

    // if the threshold is eg. 3, then the 4th click will play a clip from annoyed1
    private int annoyed1Threshold = 2;

    private int annoyed2Threshold = 4;

    private float resetTime = 1.5f;

    void Start()
    {
        audioSourceComponent = gameObject.GetComponent<AudioSource>();
    }

    public float ExitGame()
    {
        PlayRandomClip(exitGame);

        return audioSourceComponent.clip.length;
    }

    public void NeedToGuessHigher()
    {
        PlayRandomClip(needToGuessAgain);
    }

    public void NeedToGuessLower()
    {
        PlayRandomClip(needToGuessAgain);  
    }


// Beginning of poking code
    public void Poke()
    {
        if (annoyed == 0)
        {
            PlayAnnoyed0();
        }
        else if (annoyed == 1)
        {
            PlayAnnoyed1();
        }
        else if (annoyed >= 2)
        {
            PlayAnnoyed2();
        }

        pressed ++;

        if (pressed >= annoyed2Threshold)
        {
            annoyed = 2;
        }
        else if (pressed >= annoyed1Threshold)
        {
            annoyed = 1;
        }
        else
        {
            annoyed = 0;
        }
    }

    void PlayAnnoyed0()
    {
        ResetResetTimer();
        
        PlayRandomClip(annoyed0);
    }

    void PlayAnnoyed1()
    {
        ResetResetTimer();
        
        PlayRandomClip(annoyed1);      
    }

    void PlayAnnoyed2()
    {
        ResetResetTimer();
        
        PlayRandomClip(annoyed2);
    }

    private void ResetResetTimer()
    {
        StopCoroutine("ResetTimer");
        StartCoroutine("ResetTimer");
    }

    private IEnumerator ResetTimer()
    {
       yield return new WaitForSeconds(resetTime);

       pressed = 0;
       annoyed = 0;
    }
// End of poking code

    private void PlayRandomClip(AudioClip[] clips)
    {
        int index = Random.Range(0, clips.Length);

        PlayClip(clips[index]); 
    }

    private void PlayClip(AudioClip clip)
    {
        audioSourceComponent.clip = clip;
        audioSourceComponent.Play();
    }


}
