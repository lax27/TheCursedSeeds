using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//OJO todo esto est� copiado de un video de internet, luego cambiar� variables y , modificar� cosas
//link:https://www.youtube.com/watch?v=_fnG_Zh6A88

public class CooldownTimer : MonoBehaviour
{
    private float minHealth;
    [Range(0, 100)]
    public float currentHealth;
    [Range(0, 100)]
    public float maxHealth;

    public Text currentHealthText;
    public Image healthbarImage;



    // Update is called once per frame
    void Update()
    {
        currentHealthText.text = "" + currentHealth.ToString("n0");
        healthbarImage.fillAmount = currentHealth / maxHealth;

        currentHealth = Time.deltaTime;
    }
}
