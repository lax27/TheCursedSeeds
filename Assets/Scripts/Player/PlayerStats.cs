using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public int playerHealth = 3;
    public float playerSpeed = 5f;
    public int seeds = 0;
    public int cursedSeedID = 0;


    
    private void Start()
    {
        instance = this;


    }



    void Update()
    {
    }
}
