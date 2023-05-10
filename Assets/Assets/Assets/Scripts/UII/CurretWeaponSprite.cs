using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurretWeaponSprite : MonoBehaviour
{

    public List<Sprite> weaponsSprites = new List<Sprite>();
    private Image weaponImage;

    // Start is called before the first frame update
    void Start()
    {
        weaponImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentWeaponID == 0)
        {
           weaponImage.sprite = weaponsSprites[0];
        }
        if (GameManager.instance.currentWeaponID == 1)
        {
            weaponImage.sprite = weaponsSprites[1];
        }
        if (GameManager.instance.currentWeaponID == 2)
        {
            weaponImage.sprite = weaponsSprites[2];
        }
    }
}
