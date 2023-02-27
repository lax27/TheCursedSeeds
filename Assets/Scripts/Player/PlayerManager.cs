using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int life = 3;
    public int CseedOn = 0;
    public int maxCseed = 1;
    public int weaponsOn = 0;
    public int maxWeaponCapacity = 1;
    public float coolDownTime;
    //
    public GameObject player;
    public FrostSeed seed;
    //

    public GameObject uid;
    private UI ui;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mantee_test");
        seed = GetComponent<FrostSeed>();   
        uid = GameObject.Find("ui");
        ui = uid.GetComponent<UI>();

        seed = player.GetComponent<FrostSeed>();
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (life == 0)
        {
           // Destroy(player);
        }
    }

    public void GetDamage()
    {
        life--;
        ui.UpdateLife();
    }

}
