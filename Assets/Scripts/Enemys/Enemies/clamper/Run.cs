using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    private ClamperMove mv;
    private Collider2D cl;
    private GameObject ranged;
    // Start is called before the first frame update
    void Start()
    {
        mv = GetComponentInParent<ClamperMove>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.tag == "Player")
            {
                mv.dir = mv.transform.position - collision.transform.position;
                mv.dir = mv.dir.normalized;
                mv.move = true;
                mv.stoped = false;
            }
    }

}
