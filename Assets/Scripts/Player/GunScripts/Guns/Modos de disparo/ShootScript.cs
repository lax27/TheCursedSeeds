using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bullet;
    public bool canFire;
    private float timer;
    public float timeBetwenFire;
    public Transform canon = null;
    Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
        coll = bullet.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
   

        if (!canFire)
        {
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
            GameObject temp = Instantiate(bullet,canon.position,Quaternion.identity);
        }
    }
}
