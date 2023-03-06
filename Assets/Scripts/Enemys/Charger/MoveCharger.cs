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

    Vector2 dir;
    public bool isChargin = false;
    public float chargingForce = 50;

    ///CONTADORES
    public float toCharge = 5;
    public float chargeTime= 0.1f;




    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.Find("mantee_v2");
        es = GetComponent<EnemysStats>();
        rb = GetComponent<Rigidbody2D>();
        ls = pl.GetComponent<LoseGetLife>();
        ef = GetComponent<EnemyFreez>();
  
    }

    // Update is called once per frame
    void Update()
    {
        toCharge -= Time.deltaTime;
       

        if(toCharge <= 0)
        {
            isChargin = true;  
        }
        if (isChargin)
        {
            chargeTime -= Time.deltaTime;
            if(chargeTime <= 0)
            {
                rb.velocity = Vector2.zero; 
                isChargin = false;
                chargeTime = 0.3f;
                toCharge = 5;
            }
        }


        dir = new Vector2(target.position.x, target.position.y);
      
        if (!ef.isFreez)
        {
            if (ls.isDamage)
            {
                es.speed = 0;
            }
            else
            {
                es.speed = 2;
            }
        }

        if (!isChargin)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, es.speed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (isChargin)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            Debug.Log(dir);
            rb.AddForce(dir * chargingForce, ForceMode2D.Impulse);
        }
    }
}