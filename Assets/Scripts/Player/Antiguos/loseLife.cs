using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseLife : MonoBehaviour
{
    private float timer = 0;
    private PlayerManager pm;
    public GameObject playerManager;
    private Rigidbody2D rb;
    private SpriteRenderer Sb2;
    private bool isDamage = false;
    public float force = 0.5f;

    bool setKnok = false;
    Vector2 direcionEnemy;
    public float knokTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sb2 = GetComponent<SpriteRenderer>();
        playerManager = GameObject.Find("PlayerManager");
        pm = playerManager.GetComponent<PlayerManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer > 0)
        {
            Sb2.color = Color.red;
            isDamage = true;
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Sb2.color = Color.white;
                rb.velocity = new Vector2(0, 0);
                isDamage = false;
            }
        }

        if (setKnok)
        {
            knokTime -= Time.deltaTime;
        }


    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //si el enemigo es un charger:     
            if (isDamage == false)
            {
                //timer += Time.deltaTime;
                pm.GetDamage();


                 direcionEnemy = transform.position - collision.gameObject.transform.position;
                direcionEnemy = direcionEnemy.normalized * force;
                rb.AddForce(direcionEnemy, ForceMode2D.Impulse);
                    
                
                
                    
           

            
                timer = 1;
                collision.gameObject.GetComponent<ChargerMove>().chargerSpeed = 0;
                collision.gameObject.GetComponent<ChargerMove>().isMoving = false;
            }


        }
    }

}