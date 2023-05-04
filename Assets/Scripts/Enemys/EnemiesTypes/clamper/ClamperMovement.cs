using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClamperMovement : MonoBehaviour
{
    public Vector3 dir;
    private EnemiesStats enemiesStats;
    public bool isStopped = true;
    public bool isMoving = false;
    public float timerToMove = 2f; 
    public float timerMovement = 1f;
    PlayerHealthHandler playerHealthHandler;
    GameObject pl;


    void Start()
    {
        enemiesStats = GetComponent<EnemiesStats>();
        pl = GameObject.Find("mantee_v2");
        playerHealthHandler = pl.GetComponent<PlayerHealthHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealthHandler.isPlayerDead)
        {
            this.enabled = false;
        }

        if (isStopped)
        {
            dir = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360)).normalized;
        }

        if (isStopped)
        {
            timerMovement = 1f;
            timerToMove -= Time.deltaTime;
        }

        if (timerToMove <= 0)
        {
            isStopped = false;
            isMoving = true;
        }

        if (isMoving)
        {
            timerToMove = 2f;
            timerMovement -= Time.deltaTime;
        }


        if (timerMovement <= 0)
        {
            isStopped = true;
            isMoving = false;
        }

    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position += dir * enemiesStats.enemySpeed * Time.fixedDeltaTime;
        }
    }

}
