using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelection : MonoBehaviour
{
    private GameObject rotatePoint;
    // Start is called before the first frame update
    void Start()
    {
        rotatePoint = GameObject.Find("RotatePoint");
        for (int i = 0; i < rotatePoint.transform.childCount; i++)
        {
            rotatePoint.transform.GetChild(i).gameObject.SetActive(false);
        }
        rotatePoint.transform.GetChild(GameManager.instance.currentWeaponID).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
