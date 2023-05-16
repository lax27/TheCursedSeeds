using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static SoundController instance;

    [SerializeField]private AudioSource audioSource; //para balas
    [SerializeField]private AudioSource audioSourcePlayerSounds; //para sondios del pj
    [SerializeField]private AudioSource audioSourceEnemiesSounds; //para sondios del pj

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSourcePlayerSounds = GetComponent<AudioSource>();
        audioSourceEnemiesSounds = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }

    public void PlaySoundPlayer(AudioClip sound)
    {
        audioSourcePlayerSounds.PlayOneShot(sound);
    }

    public void PlaySoundEnemies(AudioClip sound)
    {
        audioSourceEnemiesSounds.PlayOneShot(sound);
    }
}

