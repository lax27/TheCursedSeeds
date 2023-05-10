using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClamperShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootSpawn;
    private bool canFire = false;
    private float timerToMove = 1.5f;
    private EnemyFrozen enemyFrozen;
    PlayerHealthHandler playerHealthHandler;
    GameObject pl;
    public float timeBetrewShot = 5f;
    public float timeBetrewShotOffset;

    // Start is called before the first frame update
    void Start()
    {
        enemyFrozen = GetComponent<EnemyFrozen>();
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

        if (enemyFrozen.isFrozen)
        {
            canFire = false;
            timerToMove = 1.5f;
        }

        timerToMove -= Time.deltaTime;

        if(gameObject.name == "clamperRapidFire Variant")
        {
            timeBetrewShot -= Time.deltaTime;
            if (timeBetrewShot <= 0)
            {
                timeBetrewShot = timeBetrewShotOffset;
                canFire = true;
            }
        }

        if (timerToMove <= 0 && gameObject.name != "clamperRapidFire Variant")
        {
            canFire = true;
            if(gameObject.name != "clamperTurret Variant")
            timerToMove = 1.5f;
            else
            {
                timerToMove = 0.4f;
            }
        }

        if (canFire)
        {
            Instantiate(bullet,shootSpawn.transform.position,Quaternion.identity);
            canFire = false;
        }
    }
}
