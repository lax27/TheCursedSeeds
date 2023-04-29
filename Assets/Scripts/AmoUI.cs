using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmoUI : MonoBehaviour
{
    private TMP_Text ammo;
    private GameObject Guns;
    public ShootScript bullets;
    private string magazine;

    private float timeBlink = 0.5f;
    private bool isBlinking = false;
    public GameObject ReloadIcon;


    // Start is called before the first frame update
    void Start()
    {
        Guns = GameObject.Find("RotatePoint");
        ammo = GameObject.Find("Amo").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Guns.transform.childCount; i++)
        {
            bullets = Guns.transform.GetChild(GameManager.instance.currentWeaponID).GetComponent<ShootScript>();
        }


        magazine = bullets.currentAmmo.ToString();
        magazine += "/";
        magazine += bullets.maxAmmo.ToString();
        ammo.text = magazine;

        if (bullets.isReloading)
        {
            timeBlink -= Time.deltaTime;
            if (timeBlink <= 0f)
            {
                timeBlink = 0.5f;
                isBlinking = !isBlinking;
            }

            if (isBlinking)
            {
                ReloadIcon.SetActive(true);
            }
            else
            {
                ReloadIcon.SetActive(false);
            }
        }
        else
        {
            ReloadIcon.SetActive(false);
        }
    }
}
