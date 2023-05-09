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
    [SerializeField] private ParticleSystem shootParticle;
    PlayerHealthHandler playerHealthHandler;
    GameObject pl;

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

        if (timerToMove <= 0)
        {
            canFire = true;
            timerToMove = 1.5f;
        }

        if (canFire)
        {
            shootParticle.Play();
            Instantiate(bullet,shootSpawn.transform.position,Quaternion.identity);
            canFire = false;
        }
    }
}
