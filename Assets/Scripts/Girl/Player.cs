using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    private Animator animator;
    private PlayerStats velocity;
    public float sp;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent < Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //illo aki no me muevo
        if(!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.S))
        {
            animator.SetFloat("Speed", 0);
        }

        //wwwwwwwwww  arriba españa
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            animator.SetFloat("Speed", 1);
            animator.SetBool("up", true);
            animator.SetBool("down", false);
            animator.SetBool("right", false);
            animator.SetBool("left", false);


        }
 


        //sssssssssubnormal abajo
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            animator.SetFloat("Speed", 1);
            animator.SetBool("up", false);
            animator.SetBool("down", true);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
        }


        //aaaaaaaaaaaa izquierda
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            animator.SetFloat("Speed", 1);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
            animator.SetBool("right", false);
            animator.SetBool("left", true);
        }



        //Derecha
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            animator.SetFloat("Speed", 1);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
            animator.SetBool("right", true);
            animator.SetBool("left", false);
        }
 

        ////abajo murcia izquierda
        //if(Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.S))
        //{
        //    animator.SetFloat("Speed", 1);
        //    animator.SetBool("up", false);
        //    animator.SetBool("down", true);
        //    animator.SetBool("right", true);
        //    animator.SetBool("left", false);
        //}
        //////abajo murcia izquierda
        //if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.A))
        //{
        //    animator.SetBool("up", false);
        //    animator.SetBool("down", true);
        //    animator.SetBool("right", false);
        //    animator.SetBool("left", true);
        //}

        ////arriba españa izquierda
        //if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
        //{
        //    animator.SetBool("up", true);
        //    animator.SetBool("down", false);
        //    animator.SetBool("right", false);
        //    animator.SetBool("left", true);
        //}

        ////arriba españa derecha
        //if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
        //{
        //    animator.SetBool("up", true);
        //    animator.SetBool("down", false);
        //    animator.SetBool("right", true);
        //    animator.SetBool("left", false);
        //}
    }
}
