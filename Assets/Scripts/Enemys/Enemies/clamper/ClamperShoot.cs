using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClamperShoot : MonoBehaviour
{
    public GameObject bullet;
    private bool canFire = false;
    private float timerbetweenShoot = 1.5f;
    private EnemyFreez ef;

    // Start is called before the first frame update
    void Start()
    {
        ef = GetComponent<EnemyFreez>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ef.isFreez)
        {
            canFire = false;
            timerbetweenShoot  = 1.5f;
        }

        timerbetweenShoot  -= Time.deltaTime;

        if (timerbetweenShoot  <= 0)
        {
            canFire = true;
            timerbetweenShoot  = 1.5f;
        }

        if (canFire)
        {
            Instantiate(bullet,transform.position,Quaternion.identity);
            canFire = false;
        }
    }
}
