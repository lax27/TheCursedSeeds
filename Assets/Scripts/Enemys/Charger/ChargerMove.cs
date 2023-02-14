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
    private SpriteRenderer sr;
    private float timer;

    //hacer una variable para velocidad actual y otra para la base

    //velocidad del charger
    public float chargerSpeed = 5f;

    public float sprintMultiplier = 2f;

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
      
        timer -= Time.deltaTime;    
        if (timer < 0.5f)
        {
            sr.color = Color.white;
        }

    
        if(life == 0)
        {
            Destroy(gameObject);
        }
        if(isFreez == true)
        {
            StartCoroutine(Freez());
        }

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
            timer = 1;
            sr.color = Color.red;
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
    IEnumerator Freez()
    {
        chargerSpeed = 0;
        sr.color = Color.blue;
        yield return new WaitForSeconds(7);
        sr.color = Color.white;
        chargerSpeed = 2;
        isFreez = false;
    }
}

