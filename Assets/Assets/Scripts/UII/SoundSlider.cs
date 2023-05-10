using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public AudioSource menuMusic;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = menuMusic.volume;
    }

    public void ChangeVolume()
    {
        menuMusic.volume = volumeSlider.value;
    }
}
