using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveCharger : MonoBehaviour
{
    Transform target;
    EnemysStats es;
    Rigidbody2D rb;

    Vector2 dir;
    public float chtimer = 10;
 
    // Start is called before the first frame update
    void Start()
    {
      
        es = GetComponent<EnemysStats>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = Vector2.MoveTowards(transform.position, target.position, es.speed * Time.deltaTime);

        
        
        

    }

    private void FixedUpdate()
    {

        if (chtimer <= 0) {

                 

           
        }






    }
}
