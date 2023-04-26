using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private GameObject aimTransform;
    private Camera mainCam;


    private void Start()
    {
        aimTransform = GameObject.Find("RotatePoint");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
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

    }

}
