using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerMove : MonoBehaviour
{
    //charger vivo
    public int life = 6;
    public bool isAlive = false;
    public bool isMoving = true;
    public bool isFreez = false;
    public bool setToFreeze = false;
    private SpriteRenderer sr;
    private float timerHit;

    public bool isHit = false;

    //hacer una variable para velocidad actual y otra para la base

    //velocidad del charger
    public float chargerSpeed = 5f;

    public float sprintMultiplier = 2f;

    private float timeToMelt = 0.0f;

    //GameObject que va a perseguir
    private Transform target;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();


        isAlive = true;

        if (isAlive == true)
        {
            StartCoroutine(SprintCooldown());

        }



        //especificando que el objetivo es "player" y que coja la información del transform de "player"
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (isHit && !setToFreeze && !isFreez)
        {
            timerHit -= Time.deltaTime;
            if (timerHit < 0.5f)
            {
                sr.color = Color.white;
                isHit = false;
            }
        } 
        
        if(life == 0)
        {
            Destroy(gameObject);
        }


        ////////// Movimiento ////////////
        ///// CONGELAMIENTO ////
        if(setToFreeze){
            freezeChar();
        }else if (isFreez){
            timeToMelt -= Time.deltaTime;

            if (isHit) {
                timerHit -= Time.deltaTime;
                if (timerHit < 0.5f)
                {
                    sr.color = Color.blue;
                    isHit = false;
                }
            }
            if(timeToMelt <= 0.0f){
                meltChar();
            }
        }
        /////////////////////////////////
        if (isMoving == false)
        {
            StartCoroutine(Rest());
            isMoving = true;
        }

        //Charger se dirije a la posición del player a la velocidad de la variable "chargerSpeed"
        transform.position = Vector2.MoveTowards(transform.position, target.position, chargerSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("bullet"))
        {
            Destroy(collision.gameObject);
            timerHit = 1;
            sr.color = Color.red;

            isHit = true;
            
            life--;
        }
    }


    IEnumerator SprintCooldown()
    {
        //al spawnear espera 3 segundos
        yield return new WaitForSeconds(3f);
        //al pasar los 3 segundos, multiplica por 2 la velocidad del charger
        chargerSpeed = chargerSpeed * sprintMultiplier;
        //espera 1 segundo
        yield return new WaitForSeconds(1f);
        //al pasar el segundo, divide por 2 la velocidad del charger
        chargerSpeed = chargerSpeed / sprintMultiplier;
    }
    
    IEnumerator Rest()
    {
            yield return new WaitForSeconds(2.5f);
            chargerSpeed = 2f;   
    }

    private void freezeChar()
    {
        chargerSpeed = 0;
        sr.color = Color.blue;
        isFreez = true;
        timeToMelt = 5.0f;
        setToFreeze = false;

    }

    private void meltChar()
    {
        setToFreeze = false;
        sr.color = Color.white;
        chargerSpeed = 2;
        isFreez = false;
        timeToMelt = 0.0f;
    }

}

