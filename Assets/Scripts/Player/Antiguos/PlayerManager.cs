using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{
    public int life = 3;
    public int CseedOn = 0;
    public int maxCseed = 1;
    public int weaponsOn = 0;
    public int maxWeaponCapacity = 1;
    int sceneID = 1;

    //
    public GameObject player;
    //

    public GameObject uid;
    private UI ui;
    // Start is called before the first frame update
    void Start()
    {
        uid = GameObject.Find("ui");
        ui = uid.GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(life == 0)
        {
            // Destroy(player);
            SceneManager.LoadScene(sceneID);
        }
    }

    public void GetDamage()
    {
        life--;
        ui.UpdateLife();
    }

}
