using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rg;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       
        Vector3 Hdirecion = new Vector3(horizontal, 0, 0);
        Vector3 Vdirecion = new Vector3(0, vertical, 0);    
        

       transform.position +=  new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);   



    }
}
