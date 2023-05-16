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
    GameObject Player;
    public float timeBetweenShots = 5f;
    public float timeBetweenShotsOffset;

    // Start is called before the first frame update
    void Start()
    {
        enemyFrozen = GetComponent<EnemyFrozen>();
        Player = GameObject.Find("mantee_v2");
        playerHealthHandler = Player.GetComponent<PlayerHealthHandler>();
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
            timeBetweenShots -= Time.deltaTime;

            if (timeBetweenShots <= 0)
            {
                timeBetweenShots = timeBetweenShotsOffset;
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
