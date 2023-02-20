using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseLife : MonoBehaviour
{
    private float timer = 0;
    private PlayerManager pm;
    public GameObject playerManager;
    private Rigidbody2D rb;
    private SpriteRenderer rb2;
    private bool isDamage = false;
    public float force = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb2 = GetComponent<SpriteRenderer>();
        playerManager = GameObject.Find("PlayerManager");
        pm = playerManager.GetComponent<PlayerManager>();

    }

    // Update is called once per frame
    void Update()
    {
        


        if (timer > 0)
        {
            rb2.color = Color.red;
            isDamage = true;
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                rb2.color = Color.white;
                rb.velocity = new Vector2(0, 0);
                isDamage = false;
            }
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

                Vector2 direcion = transform.position - collision.gameObject.transform.position;
                direcion = direcion.normalized * force;
                rb.AddForce(direcion, ForceMode2D.Impulse);
            
                timer = 1;
                collision.gameObject.GetComponent<ChargerMove>().chargerSpeed = 0;
                collision.gameObject.GetComponent<ChargerMove>().isMoving = false;
            }


        }
    }

}