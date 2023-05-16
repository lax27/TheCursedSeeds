using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    private ClamperMovement clamperMovement;
    private GameObject ranged;
    // Start is called before the first frame update
    void Start()
    {
        clamperMovement = GetComponentInParent<ClamperMovement>();
        ranged = GameObject.Find("range");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            clamperMovement.dir = clamperMovement.transform.position - collision.transform.position;
            clamperMovement.dir = clamperMovement.dir.normalized;
            clamperMovement.isMoving = true;
            clamperMovement.isStopped = false;
        }
    }
}
