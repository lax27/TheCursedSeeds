using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerMovement : MonoBehaviour
{
    public GameObject[] patrollerPointers;
    private Rigidbody2D rbPatroller;
    int destinationPointerIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        rbPatroller= GetComponent<Rigidbody2D>();
        transform.position = patrollerPointers[0].transform.position; 
    }

    // Update is called once per frame
    void Update()
    {

        float speed = 5f;

        Vector2 direction = patrollerPointers[destinationPointerIndex].transform.position - transform.position;
        direction.Normalize();


        rbPatroller.velocity = direction * speed;

        float distanceToCurrentPointer = Vector2.Distance(transform.position, patrollerPointers[destinationPointerIndex].transform.position);
        if(distanceToCurrentPointer <= 0.1f)
        {
            destinationPointerIndex++;
            if(destinationPointerIndex == patrollerPointers.Length) 
            {
                destinationPointerIndex = 0;
            }
        }
        // if la distancia con el destination es < que un numero
        //      destination pointer ++
        //      if destinationPointer > cantidadDePuntos
        //          destination pointer = 0




    }
}
