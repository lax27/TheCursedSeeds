using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprites : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private SpriteRenderer rs;
    public Animator animator;

    public List<Sprite> sprites;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rs = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); 

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if(rotZ > 90 || rotZ < -90)
        {
            rs.flipX = true;
        }else if (rotZ < 90 || rotZ > -90)
        {
            rs.flipX = false;
        }

        if(rotZ > -135 && rotZ < -45){
            //rs.sprite = sprites[2];//front
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0){
                animator.SetBool("Front", true);
                animator.SetBool("Back", false);
                animator.SetBool("Side", false);
                animator.SetBool("MoveFront", false);
                animator.SetBool("MoveSide", false);
                animator.SetBool("MoveBack", false);
            }
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                animator.SetBool("Front", false);
                animator.SetBool("Back", false);
                animator.SetBool("Side", false);
                animator.SetBool("MoveFront", true);
                animator.SetBool("MoveSide", false);
                animator.SetBool("MoveBack", false);
            }
        }
        else if(rotZ > 45 && rotZ < 135){
            //rs.sprite = sprites[1];//back
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                animator.SetBool("Front", false);
                animator.SetBool("Back", true);
                animator.SetBool("Side", false);
                animator.SetBool("MoveFront", false);
                animator.SetBool("MoveSide",false);
                animator.SetBool("MoveBack", false);
            }
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                animator.SetBool("Front", false);
                animator.SetBool("Back", false);
                animator.SetBool("Side", false);
                animator.SetBool("MoveFront", false);
                animator.SetBool("MoveSide", false);
                animator.SetBool("MoveBack", true);
            }
        } else{
            //rs.sprite = sprites[0]; //side
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                animator.SetBool("Front", false);
                animator.SetBool("Back", false);
                animator.SetBool("Side", true);
                animator.SetBool("MoveFront", false);
                animator.SetBool("MoveSide", false);
                animator.SetBool("MoveBack", false);
            }

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                animator.SetBool("Front", false);
                animator.SetBool("Back", false);
                animator.SetBool("Side", false);
                animator.SetBool("MoveFront", false);
                animator.SetBool("MoveSide", true);
                animator.SetBool("MoveBack", false);
            }
        }

    }
}
