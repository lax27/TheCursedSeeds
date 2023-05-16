using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChargerMovement : MonoBehaviour
{
    EnemiesStats enemiesStats;
    Rigidbody2D rb;
    PlayerHealthHandler playerHealthHandler;
    GameObject pl;
    EnemyFrozen enemyFrozen;
    public List<AudioClip> audioClipList = new List<AudioClip>();
    
    public Vector2 dir;
    public Vector3 dir3;
    public bool isGoingToCharge = false;
    public bool isCharging = false;
    public float chargingForce = 50;

    ///CONTADORES

    public float toCharge = 1;
    public float chargeTime= 0.1f;
    public float wait;
    public float waitOffset;
    public float enemySpeedOffset;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.Find("mantee_v2");
        enemiesStats = GetComponent<EnemiesStats>();
        rb = GetComponent<Rigidbody2D>();
        playerHealthHandler = pl.GetComponent<PlayerHealthHandler>();
        enemyFrozen = GetComponent<EnemyFrozen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealthHandler.isPlayerDead)
        {
            this.enabled = false;
        }

        wait -= Time.deltaTime;

       if(wait <= 0) {

            isGoingToCharge = true;
            toCharge -= Time.deltaTime;

            if (toCharge <= 0)
            {
                isCharging = true;
            }
       }

        if (isCharging)
        {
            chargeTime -= Time.deltaTime;

            if(chargeTime <= 0)
            {
                rb.velocity = Vector2.zero; 
                isCharging = false;
                chargeTime = 1.3f;
                toCharge = 1.5f;
            }
        }

        if (!isCharging)
        {
            dir = (pl.transform.position - transform.position).normalized;
        }
      
        if (!enemyFrozen.isFrozen)
        {
            if (playerHealthHandler.enemyAttackPaused)
            {
                enemiesStats.enemySpeed = 0;
            }
            else
            {
                enemiesStats.enemySpeed = enemySpeedOffset;
            }
        }   
    }

    private void FixedUpdate()
    {
        if (!isCharging)
        {
            dir3 = (pl.transform.position - transform.position).normalized;
            if (!isGoingToCharge)
            {
                transform.position += dir3.normalized * enemiesStats.enemySpeed * Time.fixedDeltaTime;
            }

        }

        if (isCharging && !enemyFrozen.isFrozen)
        {
            rb.velocity = Vector2.zero;      
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(dir * chargingForce, ForceMode2D.Impulse);
            isGoingToCharge = false;
            wait = waitOffset;
        }
    }
}