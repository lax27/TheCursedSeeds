using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChargerMovement : MonoBehaviour
{
    public Transform target;
    EnemiesStats enemiesStats;
    Rigidbody2D rb;
    PlayerHealthHandler playerHealthHandler;
    GameObject pl;
    EnemyFrozen enemyFrozen;
   
    public Vector2 dir;
    public Vector3 dir3;
    public bool isGoingToCharge = false;
    public bool isCharging = false;
    public float chargingForce = 50;
    

    ///CONTADORES

    public float toCharge = 1;
    public float chargeTime= 0.1f;
    public float wait = 10;





    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.Find("mantee_v2");
        enemiesStats = GetComponent<EnemiesStats>();
        rb = GetComponent<Rigidbody2D>();
        playerHealthHandler = pl.GetComponent<PlayerHealthHandler>();
        enemyFrozen = GetComponent<EnemyFrozen>();
        target = pl.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyFrozen.isFrozen)
        {
            return;
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
                chargeTime = 0.55f;
                toCharge = 1;
            }
        }

        if (!isCharging)
        {
            dir = target.transform.position - transform.position;
            dir = dir.normalized;
        }
        
      
        if (!enemyFrozen.isFrozen)
        {
            if (playerHealthHandler.enemyAttackPaused)
            {
                enemiesStats.enemySpeed = 0;
            }
            else
            {
                enemiesStats.enemySpeed = 1.5f;
            }
        }

   
    }

    private void FixedUpdate()
    {

        if (!isCharging)
        {
            dir3 = target.transform.position - transform.position;
            //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemiesStats.enemySpeed * Time.deltaTime);
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
                wait = 10;
        }
    }
}