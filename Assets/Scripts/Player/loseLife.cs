using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseLife : MonoBehaviour
{
    private PlayerManager pm;
    public GameObject playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager");
        pm = playerManager.GetComponent<PlayerManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            pm.GetDamage();
        }
    }
}
