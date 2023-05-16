using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisInSeconds : MonoBehaviour
{
    private float timerToDestroy = 5f;
   
    // Update is called once per frame
    void Update()
    {
        timerToDestroy -= Time.deltaTime;

        if (timerToDestroy <= 0)
        {
            Destroy(gameObject);    
        }
    }
}
