using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip clipJump;
    public AudioClip clipDie;
    public AudioClip clipCoin;
    public AudioClip clipPunch;
    public AudioClip clipBreak;
    public AudioClip clipGoal;

    AudioSource audioSource;
    public static AudioManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayJump()
    {
        audioSource.PlayOneShot(clipJump);
    }
    public void PlayDie()
    {
        audioSource.PlayOneShot(clipDie);
    }
    public void PlayCoin()
    {
        audioSource.PlayOneShot(clipCoin);
    }
    public void PlayPunch()
    {
        audioSource.PlayOneShot(clipPunch);
    }
    public void PlayBreak()
    {
        audioSource.PlayOneShot(clipBreak);
    }
    public void PlayGoal()
    {
        audioSource.PlayOneShot(clipGoal);
    }
}
