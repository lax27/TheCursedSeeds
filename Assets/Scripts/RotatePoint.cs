using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePoint : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform gun;
    public bool canFire;
    private float timer;
    public float timeBetwenFire;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire) {
            timer += Time.deltaTime;
            if (timer > timeBetwenFire)
            {
                canFire = true;
                timer = 0;

            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            GameObject temp = Instantiate(bullet, gun.position,Quaternion.identity);
            Destroy(temp, 3);
        }

    }
}