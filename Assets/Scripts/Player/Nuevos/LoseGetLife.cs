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

   // public GameObject uid;
    //private UI ui;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<PlayerStats>();
        

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
               // rb.velocity = new Vector2(0, 0);
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

                timer = 1;
            }
            
        }
    }
}
