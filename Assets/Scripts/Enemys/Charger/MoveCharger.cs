using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveCharger : MonoBehaviour
{
    public Transform target;
    EnemysStats es;
    Rigidbody2D rb;
    LoseGetLife ls;
    GameObject pl;
    EnemyFreez ef;
   
    public Vector2 dir;
    public Vector3 dir3;
    public bool isGoingToCharge = false;
    public bool isChargin = false;
    public float chargingForce = 50;


    ///CONTADORES

    public float toCharge = 1;
    public float chargeTime= 0.1f;
    public float wait = 10;





    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.Find("mantee_v2");
        es = GetComponent<EnemysStats>();
        rb = GetComponent<Rigidbody2D>();
        ls = pl.GetComponent<LoseGetLife>();
        ef = GetComponent<EnemyFreez>();
        target = pl.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        wait -= Time.deltaTime;
       if(wait <= 0) {
            isGoingToCharge = true;
            toCharge -= Time.deltaTime;
            if (toCharge <= 0)
            {
                isChargin = true;
            }
       }

      
        if (isChargin)
        {
            chargeTime -= Time.deltaTime;
            if(chargeTime <= 0)
            {
                rb.velocity = Vector2.zero; 
                isChargin = false;
                chargeTime = 0.55f;
                toCharge = 1;
            }
        }

        if (!isChargin)
        {
            dir = target.transform.position - transform.position;
            dir = dir.normalized;
        }
        
      
        if (!ef.isFreez)
        {
            if (ls.isDamage)
            {
                es.speed = 0;
            }
            else
            {
                es.speed = 1.5f;
            }
        }

   
    }

    private void FixedUpdate()
    {

        if (!isChargin)
        {
            dir3 = target.transform.position - transform.position;
            //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, es.speed * Time.deltaTime);
            if (!isGoingToCharge)
            {
                transform.position += dir3.normalized * es.speed * Time.fixedDeltaTime;
            }

        }

        if (isChargin && !ef.isFreez)
        {
            rb.velocity = Vector2.zero;
           
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.AddForce(dir * chargingForce, ForceMode2D.Impulse);
                isGoingToCharge = false;
                wait = 10;
        }
    }
}