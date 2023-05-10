using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoostepsSound : MonoBehaviour
{
    public AudioClip[] foostepsOnGrass;
    public AudioClip[] footstepsOnDungeon;
    public AudioClip[] foostepsOnCorridor;

    public string material;

    public static FoostepsSound instance;

    private AudioClip lastAudioClipPlayed;

    private List<AudioSource> stepSources = new List<AudioSource>();

    private void Awake()
    {
        instance = this;
    }

    bool playingStepSound = false;

    public void StopMoveSound()
    {
        playingStepSound = false;
        for (int i = 0; i < stepSources.Count;i++)
        {
            if (stepSources[i])
            {
                StartCoroutine(FadeOutRoutine(stepSources[i]));

            }
            
        }

    }

    float stepSoundFrecuency = 0.5f;
    float stepTimeoutCount = 0f;

    private void FixedUpdate()
    {
        stepTimeoutCount += Time.fixedDeltaTime;
        if(playingStepSound)
        {
            if(stepTimeoutCount >= stepSoundFrecuency)
            {
                stepTimeoutCount = 0f;
                PlayFoostepSound();

            }

        }else
        {
            stepTimeoutCount = 0f;
        }
    }

    public void StartPlayFoostepSound()
    {
        playingStepSound = true;
        PlayFoostepSound();
    }

    IEnumerator FadeOutRoutine(AudioSource aSource)
    {
        float duration = 0.2f;
        float originalVolume = aSource.volume;

        float timeCounter = 0f;
        while (timeCounter < duration)
        {
            timeCounter += Time.deltaTime;
            float t = timeCounter/ duration;
            if(aSource)
                aSource.volume = originalVolume * (1f - t);
            
            yield return null;
        }
        if (aSource)
        {
            aSource.Stop();
            aSource.volume = originalVolume;

        }


    }

    IEnumerator DestroySoundOnFinish(AudioSource source)
    {
        float duration = lastAudioClipPlayed.length;

        float timeCounter = 0f;
        while (timeCounter < duration)
        {
            timeCounter += Time.deltaTime;
            yield return null;
        }
        Destroy(source);
    }
   
    private void PlayFoostepSound()
    {
        AudioSource aSource = gameObject.AddComponent<AudioSource>();
        stepSources.Add(aSource);
        aSource.volume = Random.Range(0.9f, 1.0f);
        aSource.pitch = Random.Range(0.8f, 1.2f);

        switch (material)
        {
            case "Dungeon":
                if (footstepsOnDungeon.Length > 0)
                {
                    lastAudioClipPlayed = footstepsOnDungeon[Random.Range(0, footstepsOnDungeon.Length)];
                    aSource.PlayOneShot(lastAudioClipPlayed);
                }
                break;

            case "Corridor":
                if (foostepsOnCorridor.Length > 0)
                {
                    lastAudioClipPlayed = foostepsOnCorridor[Random.Range(0, foostepsOnCorridor.Length)];
                    aSource.PlayOneShot(lastAudioClipPlayed);
                }
                break;

            case "Grass":
                if (foostepsOnGrass.Length > 0)
                {
                    lastAudioClipPlayed = foostepsOnGrass[Random.Range(0, foostepsOnGrass.Length)];
                    aSource.PlayOneShot(lastAudioClipPlayed);
                }
                break;

            default:
                break;
        }
        StartCoroutine(DestroySoundOnFinish(aSource));

    }

    void OnCollision2DEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Dungeon":
            case "Corridor":
            case "Grass":
                material = collision.gameObject.tag;
                break;

            default:
                break;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Dungeon":
            case "Corridor":
            case "Grass":
                material = collision.gameObject.tag;
                break;

            default:
                break;
        }
    }
}
