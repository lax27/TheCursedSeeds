using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerStats playerStats;
    public SpriteRenderer spriteRenderer;
    private float enemyAttackPauseTimer = 0f;
    public bool enemyAttackPaused = false;

    public AudioSource hitSound;
    public GameObject healthUIIcon1;
    public GameObject healthUIIcon2;
    public GameObject healthUIIcon3;
    
    private float inmuneTimer = 3;
    public float inmuneTimeOffset;
    public bool isInmune = false;

    private float flashTimer = 0.5f;
    private bool isFlashing = true;


    private Rigidbody2D rbPlayer;
    
    // public GameObject uid;
    //private UI ui;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        rbPlayer = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();

        healthUIIcon1 = GameObject.Find("HP1");
        healthUIIcon2 = GameObject.Find("HP2");
        healthUIIcon3 = GameObject.Find("HP3");

        //uid = GameObject.Find("ui");
        //ui = uid.GetComponent<UI>();


    }

    // Update is called once per frame
    void Update()
    {

        if (isInmune)
        {
            inmuneTimer -= Time.deltaTime;
            //Physics2D.IgnoreLayerCollision(30, 8);

            if (inmuneTimer > 0f)
            {
                flashTimer -= Time.deltaTime;
                if (flashTimer <= 0f)
                {
                    flashTimer = 0.5f;
                    isFlashing = !isFlashing;
                }

                if (isFlashing)
                {
                    spriteRenderer.color = new Color(255, 255, 255, 0.5f);
                }
                else
                {
                    spriteRenderer.color = new Color(255, 255, 255, 1);
                }


            }

            if (inmuneTimer <= 0)
            {
                //devlover las layersColisions
                spriteRenderer.color = new Color(255, 255, 255, 255);
                inmuneTimer = inmuneTimeOffset;
                isInmune = false;
            }
        }

    /* TODO mover codigo entre "////" a un script de UI */ 
        /////////////////////////////////////////////////////
        /////CAMBIOS
        if (playerStats.life <= 0)
        {
            healthUIIcon1.SetActive(false);
            healthUIIcon2.SetActive(false);
            healthUIIcon3.SetActive(false);
        }

        if (playerStats.life == 1)
        {
            healthUIIcon2.SetActive(false);
            healthUIIcon3.SetActive(false);
        }

        if (playerStats.life == 2)
        {
            healthUIIcon3.SetActive(false);
        }
        /////////////////////////////////////////////////////
        if (enemyAttackPauseTimer > 0)
        {
            enemyAttackPaused = true;
            enemyAttackPauseTimer -= Time.deltaTime;
       
            if (enemyAttackPauseTimer <= 0)
            {
                //rbPlayer.velocity = new Vector2(0, 0);
                enemyAttackPaused = false;             
            }
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy") {
            
             if(enemyAttackPaused == false && !isInmune) {
                playerStats.life--;
                playerMovement.directionKnockedBack = transform.position - collision.gameObject.transform.position;
                playerMovement.directionKnockedBack.Normalize();
                enemyAttackPauseTimer = 1f;
                isInmune = true;
                if(hitSound != null)
                    hitSound.Play();
            }
            playerMovement.beingKnockedBack = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyB")
        {
            if (enemyAttackPaused == false && !isInmune)
            {
                playerStats.life--;
                enemyAttackPauseTimer = 1f;
                isInmune = true;
                hitSound.Play();
            }
        }
    }
}
