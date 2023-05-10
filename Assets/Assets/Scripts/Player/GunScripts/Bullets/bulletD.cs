using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletD : MonoBehaviour
{
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
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "enemyB")
        {
            Destroy(collision.gameObject);
        }
    }
}
