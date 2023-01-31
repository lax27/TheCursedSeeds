using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerMove : MonoBehaviour
{
    //color del charger
    Color chargerColor = Color.red;

    //velocidad del charger
    public float chargerSpeed = 5f;

    //que es lo que va a perseguir
    private Transform target;


    //Temporizador hasta que charger pase a "CANSADO"

        //Segundos desde el que empezará la cuenta atrás hasta que pase al estado "CANSADO"
        public float secondsTillTiredTimer = 5f;
        //Temporizador empieza desactivado
        public bool tillTiredTimerIsRunning = false;

    //Temporizador hasta que pase de "CANSADO" a "PERSEGUIR"

        //Segundos desde el que empezará la cuenta atrás hasta que pase al estado "PERSEGUIR"
        float tiredSeconds = Random.Range(1f, 3f);
        //Temporizador empieza desactivado
        public bool tiredSecondsTimerIsRunning = false;


    void Start()
    {
        //especificando que el objetivo es "player" y que coja la información del transform de "player"
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //Temporizador de en cuanto tiempo pasa de "PERSEGUIR" a "CANSADO" empieza
        tillTiredTimerIsRunning = true;

        //Declaro que el tiempo que estará "CANSADO" se cojerá del scope "tiredSeconds"
        float tiredSecondsTimer = tiredSeconds;
    }

    void Update()
    {
        //while (chargerIsAlive) *empezar scope*
            //Charger se dirije a la posición del player a la velocidad de la variable "chargerSpeed"
            transform.position = Vector2.MoveTowards(transform.position, target.position, chargerSpeed * Time.deltaTime);
            
            //Charger empieza en "PERSEGUIR", mientras el temporizador esté activo
            if (tillTiredTimerIsRunning)
                {
                    //si el timer no ha llegado a 0 sigue contando
                    if (secondsTillTiredTimer > 0){
                    secondsTillTiredTimer -= Time.deltaTime;
                    }
                    //cuando el temporizador llega a 0
                    else{
                //Está "CANSADO"

                    //mantener el temporizador de cuanto falta para llegar a "CANSADO" a 0 para que no siga corriendo en numeros negativos
                    secondsTillTiredTimer = 0f;
                    //parar el temporizador de cuanto falta para llegar a "CANSADO"
                    tillTiredTimerIsRunning = false;
                    //empieza el temporizador de cuanto tiempo estará "CANSADO"
                    tiredSecondsTimerIsRunning = true;
                    //mientras esté en 
                    while (tiredSecondsTimerIsRunning)
                    //parar el movimiento del charger
                    chargerSpeed = 0f;
                    //cada x parte del tiempo cambia el color del charger
                    chargerColor = Color.white;
                    chargerColor = Color.red;

                //mientras el temporizador de cansancio esté activo parpadea
                //CUANDO TERMINE EL BUCLE, SE REPETIRÁ HASTA QUE EL CHARGER MUERA.
            }
                }
        //finalizar scope del while

    }
}
