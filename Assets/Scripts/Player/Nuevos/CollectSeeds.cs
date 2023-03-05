using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSeeds : MonoBehaviour
{
    PlayerStats ps;
    Collider2D cl;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<PlayerStats>();   
        cl = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.tag == "curency")
        {
            ps.seeds++;

            Destroy(collision.gameObject);
        }
    }

}
