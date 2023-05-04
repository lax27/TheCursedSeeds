using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprites : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private SpriteRenderer rs;
    public Animator animator;
    private PlayerStats playerStats;

    public List<Sprite> sprites;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rs = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        if(rotZ > 90 || rotZ < -90)
        {
            rs.flipX = true;
        }else if (rotZ < 90 || rotZ > -90)
        {
            rs.flipX = false;
        }

        if(rotZ > -125 && rotZ < -65){
            //rs.sprite = sprites[2];//front
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && playerStats.life > 0){
                animator.SetBool("Front", true);
                animator.SetBool("Back", false);
                animator.SetBool("Side", false);
                animator.SetBool("MoveFront", false);
                animator.SetBool("MoveSide", false);
                animator.SetBool("MoveBack", false);
                animator.SetBool("isDead", false);
            }
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && playerStats.life > 0)
            {
                animator.SetBool("Front", false);
                animator.SetBool("Back", false);
                animator.SetBool("Side", false);
                animator.SetBool("MoveFront", true);
                animator.SetBool("MoveSide", false);
                animator.SetBool("MoveBack", false);
                animator.SetBool("isDead", false);
            }
        }
        else if(rotZ > 65 && rotZ < 125){
            //rs.sprite = sprites[1];//back
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && playerStats.life > 0)
            {
                animator.SetBool("Front", false);
                animator.SetBool("Back", true);
                animator.SetBool("Side", false);
                animator.SetBool("MoveFront", false);
                animator.SetBool("MoveSide",false);
                animator.SetBool("MoveBack", false);
                animator.SetBool("isDead", false);
            }
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && playerStats.life > 0)
            {
                animator.SetBool("Front", false);
                animator.SetBool("Back", false);
                animator.SetBool("Side", false);
                animator.SetBool("MoveFront", false);
                animator.SetBool("MoveSide", false);
                animator.SetBool("MoveBack", true);
                animator.SetBool("isDead", false);
            }
        } else{
            //rs.sprite = sprites[0]; //side
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && playerStats.life > 0)
            {
                animator.SetBool("Front", false);
                animator.SetBool("Back", false);
                animator.SetBool("Side", true);
                animator.SetBool("MoveFront", false);
                animator.SetBool("MoveSide", false);
                animator.SetBool("MoveBack", false);
                animator.SetBool("isDead", false);
            }

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && playerStats.life > 0)
            {
                animator.SetBool("Front", false);
                animator.SetBool("Back", false);
                animator.SetBool("Side", false);
                animator.SetBool("MoveFront", false);
                animator.SetBool("MoveSide", true);
                animator.SetBool("MoveBack", false);
                animator.SetBool("isDead", false);
            }

            if (playerStats.life <= 0)
            {
                animator.SetBool("Front", false);
                animator.SetBool("Back", false);
                animator.SetBool("Side", false);
                animator.SetBool("MoveFront", false);
                animator.SetBool("MoveSide", false);
                animator.SetBool("MoveBack", false);
                animator.SetTrigger("isDead");

                Destroy(this);
            }
        }

    }
}
