using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadUI : MonoBehaviour
{
    private GameObject guns;
    [SerializeField]private Transform playerPos;
    private ShootScript shotScript;
    [SerializeField]private Slider reloadIndicator;
    [SerializeField] private GameObject visible;
    // Start is called before the first frame update
    void Start()
    {
        guns = GameObject.Find("RotatePoint");
        visible.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position;

        for (int i = 0; i < guns.transform.childCount; i++)
        {
            if (GameManager.instance.currentWeaponID == i)
            {
                shotScript = guns.transform.GetChild(i).gameObject.GetComponent<ShootScript>();
            }
        }
        reloadIndicator.maxValue = shotScript.reloadTimeOffset;

        if (shotScript.isReloading) {
            visible.SetActive(true);
            reloadIndicator.value += Time.deltaTime;           
        }
        else
        {
            reloadIndicator.value = 0;
            visible.SetActive(false);
        }
    }
}
