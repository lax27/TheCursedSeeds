using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClamperShoot : MonoBehaviour
{
    public GameObject bullet;
    private bool canFire = false;
    private float timer = 1.5f;
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
            timer = 1.5f;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            canFire = true;
            timer = 1.5f;
        }

        if (canFire)
        {
            Instantiate(bullet,transform.position,Quaternion.identity);
            canFire = false;
        }
    }
}
