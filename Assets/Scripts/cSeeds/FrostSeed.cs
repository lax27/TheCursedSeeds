using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostSeed : MonoBehaviour
{
    private GameObject enemy;
    private ChargerMove ch;
    public float cooldown = 20;
    private float Currentcooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Fly-Sheet_3");
        ch = enemy.GetComponent<ChargerMove>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Currentcooldown > 0)
        {
            Currentcooldown -= Time.deltaTime;
        }
        

        if (Input.GetButtonDown("cseed") && Currentcooldown <= 0)
        {
            Currentcooldown = cooldown;
            ch.setToFreeze = true;
           
        }
     
    }
}