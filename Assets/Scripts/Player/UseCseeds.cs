using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseCseeds : MonoBehaviour
{
    PlayerStats ps;

    private GameObject[] enemys;
   // private List<ChargerMove> chs;
    private List<EnemyFrozen> chs;

    public float Currentcooldown = 0;
    public float DeathCooldown = 40;
    public float Frostcooldown = 20;
    public float LifeCooldown = 10;
    public float FireCooldown = 5;
    
    // Start is called before the first frame update
    void Start()
    {

        ps = GetComponent<PlayerStats>();

        enemys = GameObject.FindGameObjectsWithTag("enemy");

        //chs = new List<ChargerMove>();
        chs = new List<EnemyFrozen>();

        for (int i = 0; i < enemys.Length; i++)
        {
            EnemyFrozen freez = enemys[i].GetComponent<EnemyFrozen>();
            if (freez != null)
            {
                chs.Add(freez);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Currentcooldown > 0)
        {
            Currentcooldown -= Time.deltaTime;
           //Debug.Log(Currentcooldown);
        }

        //Para la Atumm seed, CseedID == 1
        if (Input.GetButtonDown("cseed") && Currentcooldown <= 0 && ps.cursedSeedID == 1) {

            Currentcooldown = DeathCooldown;
        }

        //Para la Frost seed, CseedID == 2
        if (Input.GetButtonDown("cseed") && Currentcooldown <= 0 && ps.cursedSeedID == 2) {

            Currentcooldown = Frostcooldown;

            for (int i = 0; i < chs.Count; i++) {
                chs[i].setToFreeze = true;
            }
        }
        //Para la spring seed, CseedID == 3
        if (Input.GetButtonDown("cseed") && Currentcooldown <= 0 && ps.cursedSeedID == 3) {
            Currentcooldown = LifeCooldown;
        }

        //Para la  summer seed, CseedID == 4
        if (Input.GetButtonDown("cseed") && Currentcooldown <= 0 && ps.cursedSeedID == 4) {
            Currentcooldown = FireCooldown;
        }

    }
}
