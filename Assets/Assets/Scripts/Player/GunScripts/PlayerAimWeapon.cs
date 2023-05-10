using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private GameObject aimTransform;
    private Camera mainCam;
    public Vector3 mousePos;
    private GameObject guns;

    private void Start()
    {
        aimTransform = GameObject.Find("RotatePoint");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        guns = GameObject.Find("RotatePoint");

    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 aimDirection = (mousePos - gameObject.transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.transform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 aimLocalScale = Vector3.one;

        if(angle > 90f || angle < -90f) 
        {
            aimLocalScale.y = -1f;
        }
        else
        {
            aimLocalScale.y = 1f;
        }
        for (int i = 0; i < aimTransform.transform.childCount;i++)
        {
            aimTransform.transform.GetChild(i).gameObject.transform.localScale = aimLocalScale;
        }

        for (int i = 0; i < guns.transform.childCount; i++)
        {
            
            if(i == GameManager.instance.currentWeaponID)
            {
                SpriteRenderer gunSprite = guns.transform.GetChild(i).GetComponent<SpriteRenderer>();
                GameObject handsObject = guns.transform.GetChild(i).GetChild(0).gameObject;
                if (angle > 65 && angle < 125)
                {
                    gunSprite.sortingLayerName = "details";
                    handsObject.SetActive(false);
                }
                else
                {
                    gunSprite.sortingLayerName = "ice cube";
                    handsObject.SetActive(true);
                }
                
            }
        }
    }
}
