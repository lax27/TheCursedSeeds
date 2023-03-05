using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGetLife : MonoBehaviour
{
    PlayerStats ps;
    Collider2D cl;
    public SpriteRenderer Sp;
    private float timer = 0;
    private bool isDamage = false;

    public Vector3 direcionEnemy;
    public float KonkBackForce = 10;
    private Rigidbody2D rbPlayer;
    
    // public GameObject uid;
    //private UI ui;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<PlayerStats>();
        rbPlayer = GetComponent<Rigidbody2D>();
     
        //uid = GameObject.Find("ui");
        //ui = uid.GetComponent<UI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ps.life == 0) {
            Debug.Log("Feedeastes perro");
        }

        if (timer > 0)
        {

           Sp.color = Color.red;
            isDamage = true;
            timer -= Time.deltaTime;

       
            if (timer <= 0)
            {
                Sp.color = Color.white;
                //rbPlayer.velocity = new Vector2(0, 0);
                isDamage = false;

             
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy") {
            
            if(isDamage == false) {
                ps.life--;
                //ui.UpdateLife();
                direcionEnemy = transform.position - collision.gameObject.transform.position;
                direcionEnemy = direcionEnemy.normalized * KonkBackForce * Time.deltaTime;
                transform.position += direcionEnemy; //FUNCIONA
                //rbPlayer.AddForce(direcionEnemy, ForceMode2D.Impulse); //NO FUNCIONA, si en el Pmove esta con el rbPlayer.MovePosition
                                                                         //FUNCIONA, si en el Pmove esta con el rbPlayer.addForce

                

                timer = 1;
            }

        }
    }
}
