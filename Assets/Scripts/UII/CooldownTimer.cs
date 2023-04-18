using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//SCRIPT EN DESUSO (se iba a usar para una barra de cooldown de la semilla)

//OJO todo esto está copiado de un video de internet, luego cambiaré variables y , modificaré cosas
//link:https://www.youtube.com/watch?v=_fnG_Zh6A88

public class CooldownTimer : MonoBehaviour
{
    private float minCooldown;
    [Range(0, 100)]
    public float currentCooldown;
    [Range(0, 100)]
    public float maxCooldown;

    public Text currentCooldownText;
    public Image cooldownBarImage;



    // Update is called once per frame
    void Update()
    {
        currentCooldownText.text = "" + currentCooldown.ToString("n0");
        cooldownBarImage.fillAmount = currentCooldown / maxCooldown;
        currentCooldown = Time.deltaTime;
    }
}
