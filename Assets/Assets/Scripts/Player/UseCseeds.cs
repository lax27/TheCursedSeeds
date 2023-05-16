using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseCseeds : MonoBehaviour
{
    //WTF ES CHS?????

    PlayerStats playerStats;

    private GameObject[] enemies;
   // private List<ChargerMove> chs;
    private List<EnemyFrozen> chs;

    public float currentCooldown = 0;
    public float deathCooldown = 40;
    public float frostCooldown = 20;
    public float lifeCooldown = 10;
    public float fireCooldown = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();

        enemies = GameObject.FindGameObjectsWithTag("enemy");

        //chs = new List<ChargerMove>();
        chs = new List<EnemyFrozen>();

        for (int i = 0; i < enemies.Length; i++)
        {
            EnemyFrozen freez = enemies[i].GetComponent<EnemyFrozen>();
            if (freez != null)
            {
                chs.Add(freez);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
           //Debug.Log(Currentcooldown);
        }

        //Para la Atumm seed, CseedID == 1
        if (Input.GetButtonDown("cseed") && currentCooldown <= 0 && playerStats.cursedSeedID == 1) {

            currentCooldown = deathCooldown;
        }

        //Para la Frost seed, CseedID == 2
        if (Input.GetButtonDown("cseed") && currentCooldown <= 0 && playerStats.cursedSeedID == 2) {

            currentCooldown = frostCooldown;

            for (int i = 0; i < chs.Count; i++) {
                chs[i].setToFreeze = true;
            }
        }

        //Para la spring seed, CseedID == 3
        if (Input.GetButtonDown("cseed") && currentCooldown <= 0 && playerStats.cursedSeedID == 3) {
            currentCooldown = lifeCooldown;
        }

        //Para la  summer seed, CseedID == 4
        if (Input.GetButtonDown("cseed") && currentCooldown <= 0 && playerStats.cursedSeedID == 4) {
            currentCooldown = fireCooldown;
        }
    }
}
