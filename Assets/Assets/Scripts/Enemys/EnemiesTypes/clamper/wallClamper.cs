using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallClamper : MonoBehaviour
{
    private ClamperMovement clamperMovement;
    [SerializeField]private Collider2D cl; 
    // Start is called before the first frame update
    void Start()
    {
        clamperMovement = GetComponentInParent<ClamperMovement>();
        cl = GetComponent<Collider2D>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "wall" && cl != null)
    //    {
    //        clamperMovement.dir = clamperMovement.dir - clamperMovement.transform.position;
    //        clamperMovement.dir = clamperMovement.dir.normalized;
    //        clamperMovement.isMoving = true;
    //        clamperMovement.isStopped = false;
    //    }
    //}
}
