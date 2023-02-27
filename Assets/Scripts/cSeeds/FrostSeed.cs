using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostSeed : MonoBehaviour
{
  
    private GameObject[] enemys;
    private List<ChargerMove> chs;
    public float cooldown = 20;
    public float Currentcooldown = 0;
    // Start is called before the first frame update
    void Start()
    {

        enemys = GameObject.FindGameObjectsWithTag("enemy");

        chs = new List<ChargerMove>();
        
        for(int i = 0; i < enemys.Length; i++)
        {
            ChargerMove chargerMove = enemys[i].GetComponent<ChargerMove>();
            if(chargerMove != null)
            {
                chs.Add(chargerMove);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Currentcooldown > 0)
        {
            Currentcooldown -= Time.deltaTime;
        }
        

        if (Input.GetButtonDown("cseed") && Currentcooldown <= 0)
        {
            for(int i = 0; i < chs.Count; i++)
            {

                Currentcooldown = cooldown;
                chs[i].setToFreeze = true;
            }
            
           
        }
     
    }
}