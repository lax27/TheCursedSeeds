using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSeeds : MonoBehaviour
{
    PlayerStats ps;
    Collider2D cl;
    private Wseeds ws;
    public AudioSource picking;

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
        if  (collision.tag == "curency") {

           Reference rf = collision.gameObject.GetComponent<Reference>();
            
            if (rf.ws.id_Wseed == 0)
            {
                GameManager.instance.inventory[0]++;
                picking.Play();
            }
            else if (rf.ws.id_Wseed == 1)
            {
                GameManager.instance.inventory[1]++;
                picking.Play();
            }

            Destroy(collision.gameObject);
        }
    }

}
