using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerMove : MonoBehaviour
{
    //velocidad del charger
    public float chargerSpeed = 5f;

    //GameObject que va a perseguir
    private Transform target;

    void Start()
    {
        //especificando que el objetivo es "player" y que coja la información del transform de "player"
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        //Charger se dirije a la posición del player a la velocidad de la variable "chargerSpeed"
        transform.position = Vector2.MoveTowards(transform.position, target.position, chargerSpeed * Time.deltaTime);
    }
}
