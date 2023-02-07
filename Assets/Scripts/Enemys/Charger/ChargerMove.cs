using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerMove : MonoBehaviour
{
    //charger vivo
    public bool isAlive = false;

    //velocidad del charger
    public float chargerSpeed = 5f;

    public float sprintMultiplier = 2f;

    //GameObject que va a perseguir
    private Transform target;

    void Start()
    {
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
        //Charger se dirije a la posición del player a la velocidad de la variable "chargerSpeed"
        transform.position = Vector2.MoveTowards(transform.position, target.position, chargerSpeed * Time.deltaTime);
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
}
