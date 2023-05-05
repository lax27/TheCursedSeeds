using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGetLife : MonoBehaviour
{
    Pmove pm;
    PlayerStats ps;
    Collider2D cl;
    public SpriteRenderer Sp;
    private float timer = 0;
    public bool isDamage = false;
    public AudioSource hitSound;
 


    public Vector3 direcionEnemy;
    private Rigidbody2D rbPlayer;
    
    // public GameObject uid;
    //private UI ui;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<PlayerStats>();
        rbPlayer = GetComponent<Rigidbody2D>();
        pm = GetComponent<Pmove>();
     
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
                direcionEnemy = direcionEnemy.normalized;
                timer = 1;
                hitSound.Play();
            }
            pm.isK = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyB")
        {
            if (isDamage == false)
            {
                ps.life--;
                timer = 1;
                hitSound.Play();
            }
        }
    }
}
