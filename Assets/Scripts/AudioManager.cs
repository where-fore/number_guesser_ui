using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSourceComponent = null;

    [SerializeField]
    private AudioClip startingClip = null;
    
    [SerializeField]
    private AudioClip[] beginGame = null;
    
    [SerializeField]
    private AudioClip[] guessedRight = null;
    
    [SerializeField]
    private AudioClip[] restartGame = null;

    [SerializeField]
    private AudioMixerSnapshot loadingSnapshot = null;

    [SerializeField]
    private AudioMixerSnapshot playingSnapshot = null;

    private GameObject peon = null;

    [SerializeField]
    private float transitionTime = 4f;

    private float delayBeforeStartingScript = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceComponent = gameObject.GetComponent<AudioSource>();
        loadingSnapshot.TransitionTo(0f);

        StartCoroutine("StartingClip");

    }

    private IEnumerator StartingClip()
    {
        yield return new WaitForSeconds(delayBeforeStartingScript);

        PlayClip(startingClip);
    }

    // Update is called once per frame
    void Update()
    {
        bool played = false;
        if (!peon)
        {
            peon = GameObject.FindGameObjectWithTag("Peon");
        }
        else if (peon && !played)
        {
            FadeMusic();
        }
        
    }

    private void FadeMusic()
    {
        playingSnapshot.TransitionTo(transitionTime);
    }

    public void BeginGame()
    {
        PlayRandomClip(beginGame);
    }

    public void GuessedRight()
    {
        PlayRandomClip(guessedRight);
    }

    public void RestartGame()
    {
        PlayRandomClip(restartGame);
    }

    private void PlayRandomClip(AudioClip[] clips)
    {
        int index = Random.Range(0, clips.Length);

        PlayClip(clips[index]); 
    }

    private void PlayClip(AudioClip clip)
    {
        audioSourceComponent.PlayOneShot(clip);
    }

}
