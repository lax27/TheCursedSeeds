using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthHandler : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerStats playerStats;
    public SpriteRenderer spriteRenderer;
    private float enemyAttackPauseTimer = 0f;
    public bool enemyAttackPaused = false;
    float timeDeath = 4;


    public AudioClip hitSound;
    public GameObject healthUIIcon1;
    public GameObject healthUIIcon2;
    public GameObject healthUIIcon3;
    
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

        healthUIIcon1 = GameObject.Find("HP1");
        healthUIIcon2 = GameObject.Find("HP2");
        healthUIIcon3 = GameObject.Find("HP3");



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
            //manager things 
            DungeonManager.instance.currentRoomsPositions.Clear();
            DungeonManager.instance.currentRoomsPositions.Add(Vector2.zero);
            DungeonManager.instance.RoomsObjecs.Clear();
            DungeonManager.instance.bossRoomBugs.Clear();

            timeDeath -= Time.deltaTime;
            Debug.Log(timeDeath);
            if (timeDeath <= 0)
            {
                //WAIT FEW SECONDS AND changeScene to hub and set weapon id to 0
                GameManager.instance.currentWeaponID = 0;
                // 1 = hub
                SceneManager.LoadScene(1);
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


            }
        }
    }
}