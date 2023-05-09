using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthHandler : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerStats playerStats;
    public SpriteRenderer spriteRenderer;
    private float enemyAttackPauseTimer = 0f;
    public bool enemyAttackPaused = false;
    float timeDeath = 4;


    public AudioClip hitSound;
    
    private float inmuneTimer = 3;
    public float inmuneTimeOffset;
    public bool isInmune = false;

    private float flashTimer = 0.5f;
    private bool isFlashing = true;
    private HitStop hitStop;
    private GameObject mainCamera;
    private CameraShake shake;
    [SerializeField] private ParticleSystem hitSplash;
    private GameObject guns;
    public bool isPlayerDead = false;
    private Collider2D coll;

    //UI things:
    private GameObject UI;
    private hpUI lifeUI;
    private bool isHitGlowUI = false;
    private float lifeGlowTimer = 1f;
    private Color transparentColor;

    private GameObject noHp;
    private GameObject hp;
    private Transform normalhpPosition;
    private Animator hpAnimator;
    private Animator noHpAnimator;
    
    

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerMovement = GetComponent<PlayerMovement>();
        hitStop = GetComponent<HitStop>();
        mainCamera = GameObject.Find("Main Camera");
        guns = GameObject.Find("RotatePoint");
        shake = mainCamera.GetComponent<CameraShake>();
        hitSplash = GetComponent<ParticleSystem>();
        coll = GetComponent<Collider2D>();
        UI = GameObject.Find("UI");
        lifeUI = UI.GetComponent<hpUI>();
        transparentColor = new Color(255, 255, 255, 0.1f);

        hp = GameObject.Find("HP");
        hpAnimator = hp.GetComponent<Animator>();
        noHp = GameObject.Find("LostHP");
        noHpAnimator = noHp.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInmune)
        {
            inmuneTimer -= Time.deltaTime;
            Physics2D.IgnoreLayerCollision(7, 8, true);

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
                Physics2D.IgnoreLayerCollision(7, 8, false);
                //devlover las layersColisions
                spriteRenderer.color = new Color(255, 255, 255, 255);
                inmuneTimer = inmuneTimeOffset;
                isInmune = false;
            }
        }


        if (playerStats.life <= 0)
        {
            playerMovement.enabled = false;
            guns.SetActive(false);
            coll.enabled = false;
            isPlayerDead = true;
           

            timeDeath -= Time.deltaTime;
            Debug.Log(timeDeath);
            if (timeDeath <= 0)
            {
                //WAIT FEW SECONDS AND changeScene to hub and set weapon id to 0
                GameManager.instance.currentWeaponID = 0;
                // 1 = hub
                SceneManager.LoadScene("HUB_HUB");
            }

        }
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

        if (isHitGlowUI)
        {
            lifeGlowTimer -= Time.deltaTime;

            //hacer una animacion donde la barra de vida haga un shake
            hpAnimator.SetBool("shake", true);
            noHpAnimator.SetBool("shake", true);
        }

        Debug.Log(lifeGlowTimer);
        //life Feedback:
        if (lifeGlowTimer <= 0)
        {
            for (int i = 0; i < lifeUI.lifesIcons.Length; i++)
            {

                Image life = lifeUI.lifesIcons[i].GetComponent<Image>();
                life.color = transparentColor;

                Image noLife = lifeUI.noLifesIcons[i].GetComponent<Image>();
                noLife.color = transparentColor;
            }

            hp.transform.position = normalhpPosition.position;
            noHp.transform.position = normalhpPosition.position;


            lifeGlowTimer = 1f;
            isHitGlowUI = false;
            hpAnimator.SetBool("shake", false);
            noHpAnimator.SetBool("shake", false);

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
                isHitGlowUI = true;

                if (hitSound != null)
                    SoundController.instance.PlaySoundPlayer(hitSound);

                hitSplash.Play();

                shake.CameraShakeSettings(0.1f, 0.1f);

                if (playerStats.life <= 0 && !shake.isFinish)
                {
                    hitStop.StopTime(0.05f, 10, 2.5f);
                }
                else
                {
                    hitStop.StopTime(0.05f, 20, 0.1f);
                }

                //UI
                for (int i = 0; i < lifeUI.lifesIcons.Length; i++)
                {

                    Image life = lifeUI.lifesIcons[i].GetComponent<Image>();
                    life.color = new Color(255, 255, 255, 255);

                    Image noLife = lifeUI.noLifesIcons[i].GetComponent<Image>();
                    noLife.color = new Color(255, 255, 255, 255);
                }

   
            }
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
                isHitGlowUI = true;

                if (hitSound != null)
                    SoundController.instance.PlaySoundPlayer(hitSound);

                hitSplash.Play();

                shake.CameraShakeSettings(0.1f, 0.1f);

                if (playerStats.life <= 0 && shake.isFinish)
                {
                    hitStop.StopTime(0.05f, 10, 2.5f);
                }
                else
                {
                    hitStop.StopTime(0.05f, 20, 0.1f);
                }

                //UI
                for (int i = 0; i < lifeUI.lifesIcons.Length; i++)
                {

                    Image life = lifeUI.lifesIcons[i].GetComponent<Image>();
                    life.color = new Color(255, 255, 255, 255);

                    Image noLife = lifeUI.noLifesIcons[i].GetComponent<Image>();
                    noLife.color = new Color(255, 255, 255, 255);
                }
            }
        }
    }
}
