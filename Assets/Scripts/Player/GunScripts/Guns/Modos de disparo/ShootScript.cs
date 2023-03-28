using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shells;
    public bool canFire;
    private float timer;
    public float timeBetwenFire;
    private AudioSource au;
    public Transform canon = null;
    Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
        coll = bullet.GetComponent<Collider2D>();
        au = GetComponent<AudioSource>();
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
            if (gameObject.name == "BasicGun")
            {
                //Hacer el fogonazo del arma

                //Hacer sonido de disparo
                au.Play();
                //Casquillos
                Instantiate(shells, transform.position, Quaternion.identity);
                //Camerashake

                //Spawn de la bala
                GameObject temp = Instantiate(bullet, canon.position, Quaternion.identity);
            }
            if (gameObject.name == "ShotGun")
            {
                //hacer sonido de disparo
                //instacniar casiquillos
                //camerashake
                GameObject temp = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp2 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp3 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp4 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp5 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp6 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp7 = Instantiate(bullet, canon.position, Quaternion.identity);
                GameObject temp8 = Instantiate(bullet, canon.position, Quaternion.identity);

            }
        }
    }
}
