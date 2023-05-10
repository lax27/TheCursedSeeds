using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmoUI : MonoBehaviour
{
    private TMP_Text ammo;
    private GameObject guns;
    public ShootScript bullets;
    private string magazine;

    private float timeBlink = 0.5f;
    private bool isBlinking = false;
    public GameObject ReloadIcon;


    // Start is called before the first frame update
    void Start()
    {
        guns = GameObject.Find("RotatePoint");
        ammo = GameObject.Find("Amo").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < guns.transform.childCount; i++)
        {
            bullets = guns.transform.GetChild(GameManager.instance.currentWeaponID).GetComponent<ShootScript>();
        }


        magazine = bullets.currentAmmo.ToString();
        magazine += "/";
        magazine += bullets.maxAmmo.ToString();
        ammo.text = magazine;
    }
}
