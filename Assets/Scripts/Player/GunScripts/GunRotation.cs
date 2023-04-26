using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private Camera mainCam;
    public Vector3 mousePos;
    public SpriteRenderer gunSpriteRenderer;
    // Start is called before the first frame update
    void Start() {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
   
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        bool invertGunSpriteRenderer = rotZ > 90f || rotZ < -90f;
        gunSpriteRenderer.flipY= invertGunSpriteRenderer;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);


    }
}


