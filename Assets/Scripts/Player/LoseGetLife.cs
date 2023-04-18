using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGetLife : MonoBehaviour
{
<<<<<<< HEAD
    Pmove pm;
    PlayerStats ps;
    Collider2D cl;
    public SpriteRenderer sr;
    private float timer = 0;
    public bool isDamage = false;
    public AudioSource hitSound;
=======
    private Pmove pm;
    private PlayerStats ps;
    private Collider2D cl;
    public SpriteRenderer Sp;
    private float timer = 0;
    public bool isDamage = false;
    public AudioSource hitSound;
    private float inmuneTime = 3;
    public float inmuneTimeOfsset;
    public bool inmune = false;
    private SimpleFlash flash;

  

    public GameObject HP1;
>>>>>>> c21fc3bf8f443de337acb38eb6b31e6d3f209763
    public GameObject HP2;
    public GameObject HP3;
    
    public Vector3 direcionEnemy;
    private Rigidbody2D rbPlayer;
    
    // public GameObject uid;
    //private UI ui;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("mantee_v2");

        ps = player.GetComponent<PlayerStats>();
        rbPlayer = GetComponent<Rigidbody2D>();
        pm = GetComponent<Pmove>();
        cl = GetComponent<Collider2D>();
        flash = GetComponent<SimpleFlash>();

        HP2 = GameObject.Find("HP2");
        HP3 = GameObject.Find("HP3");

        //uid = GameObject.Find("ui");
        //ui = uid.GetComponent<UI>();

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
=======
        if (inmune)
        {
            inmuneTime -= Time.deltaTime;
            cl.enabled = false;
            if (inmuneTime > 0)
            {
                flash.FlashP(0.2f);
            }
            if (inmuneTime <= 0)
            {
                cl.enabled = true;
                inmuneTime = inmuneTimeOfsset;
                inmune = false;
            }
        }
        if (ps.life == 0)
        {
            HP1.SetActive(false);
            HP2.SetActive(false);
            HP3.SetActive(false);
        }

>>>>>>> c21fc3bf8f443de337acb38eb6b31e6d3f209763
        if (ps.life == 1)
        {
            HP2.SetActive(false);
            HP3.SetActive(false);
        }

        if (ps.life == 2)
        {
            HP3.SetActive(false);
        }

        if (timer > 0)
        {

<<<<<<< HEAD
            sr.color = Color.red;
=======
            
>>>>>>> c21fc3bf8f443de337acb38eb6b31e6d3f209763
            isDamage = true;
            timer -= Time.deltaTime;

       
            if (timer <= 0)
            {
<<<<<<< HEAD
                sr.color = Color.white;
=======
>>>>>>> c21fc3bf8f443de337acb38eb6b31e6d3f209763
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
                inmune = true;
                if (hitSound != null)
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
                inmune = true;
                hitSound.Play();
            }
        }
    }
}
