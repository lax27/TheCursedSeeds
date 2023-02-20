using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostSeed : MonoBehaviour
{
    private GameObject enemy;
    private ChargerMove ch;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Fly-Sheet_3");
        ch = enemy.GetComponent<ChargerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("cseed"))
        {
            ch.setToFreeze = true;

        }
    }
}