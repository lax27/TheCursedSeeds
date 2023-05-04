using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoostepsSound : MonoBehaviour
{
    public AudioClip[] foostepsOnGrass;
    public AudioClip[] footstepsOnDungeon;
    public AudioClip[] foostepsOnCorridor;

    public string material;

    void PlayFoostepSound()
    {
        AudioSource aSource = GetComponent<AudioSource>();
        aSource.volume = Random.Range(0.9f, 1.0f);
        aSource.pitch = Random.Range(0.8f, 1.2f);

        switch (material)
        {
            case "Dungeon":
                if (footstepsOnDungeon.Length > 0)
                    aSource.PlayOneShot(footstepsOnDungeon[Random.Range(0, footstepsOnDungeon.Length)]);
                break;

            case "Corridor":
                if (foostepsOnCorridor.Length > 0)
                    aSource.PlayOneShot(foostepsOnCorridor[Random.Range(0, foostepsOnCorridor.Length)]);
                break;

            case "Grass":
                if (foostepsOnGrass.Length > 0)
                    aSource.PlayOneShot(foostepsOnGrass[Random.Range(0, foostepsOnGrass.Length)]);
                break;

            default:
                break;
        }
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
            case "Wood":
            case "Corridor":
            case "Grass":
                material = collision.gameObject.tag;
                break;

            default:
                break;
        }
    }
}
