using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShit : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer sr;
    private ParticleSystem flys;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        flys = GetComponent<ParticleSystem>();

        int randomShit = Random.Range(0, 99);
        int radmoFly = Random.Range(0, 99);

        if (randomShit == 40 || randomShit == 60 || randomShit == 99 || randomShit == 1 || randomShit == 20)
        {
            sr.sprite = sprites[0];
        }
        else
        {
            sr.sprite = sprites[1];
        }

        if (radmoFly <= 80)
        {
            Destroy(flys);
        }
    }

}
