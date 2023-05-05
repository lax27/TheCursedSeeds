using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallClamper : MonoBehaviour
{
    private ClamperMovement clamperMovement;
    private Collider2D cl; 
    private GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        clamperMovement = GetComponentInParent<ClamperMovement>();
        wall = GameObject.Find("wall");
        cl = wall.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
        {
            clamperMovement.dir = clamperMovement.dir - clamperMovement.transform.position;
            clamperMovement.dir = clamperMovement.dir.normalized;
            clamperMovement.isMoving = true;
            clamperMovement.isStopped = false;
        }
    }
}
