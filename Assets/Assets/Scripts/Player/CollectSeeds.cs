using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSeeds : MonoBehaviour
{

    [SerializeField] private AudioClip pickSound;
    //public AudioSource picking;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.tag == "curency") {

           SoundController.instance.PlaySound(pickSound);
           Reference rf = collision.gameObject.GetComponent<Reference>(); 
            if (rf.ws.id_Wseed == 0)
            {
                GameManager.instance.inventory[0]++;
            }
            else if (rf.ws.id_Wseed == 1)
            {
                GameManager.instance.inventory[1]++;
            }
            Destroy(collision.gameObject);
        }
    }

}
