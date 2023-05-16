using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDeath : MonoBehaviour
{
    EnemiesStats enemiesStats;
  
    private SimpleFlash flash;
    private ParticleSystem blood;
    public GameObject deathSplash;

    float timerHit = 0f;
    public bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        blood = GetComponent<ParticleSystem>();
        flash = GetComponent<SimpleFlash>();
        enemiesStats = GetComponent<EnemiesStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesStats.enemyHealth <= 0) {

            for (int i = 0; i < Random.Range(3,10); i++)
            {
              Instantiate(deathSplash, transform.position, Quaternion.identity);
            }
            GetComponent<LootBag>().InstatianteWseed(transform.position);
            Destroy(gameObject);
        }

        if (isHit)
        {
            timerHit -= Time.deltaTime;

            if (timerHit < 0.5f)
            {
                isHit = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("bullet"))
        {
            BulletStats bs;
            bs = collision.GetComponent<BulletStats>();
            Destroy(collision.gameObject);
            timerHit = 1;
            flash.FlashP(0.2f);

            isHit = true;

            blood.Play();

            enemiesStats.enemyHealth -= bs.damage;
        }
    }
}
