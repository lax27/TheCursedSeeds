using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    private GameObject intreactionZone;
    private PlantZone pl;
    // Start is called before the first frame update
    void Start()
    {
        intreactionZone = GameObject.Find("interaction");
        pl = intreactionZone.GetComponent<PlantZone>();
    }

    // Update is called once per frame
    void Update()
    {
      if(pl.inRange && GameManager.instance.isWeapon && Input.GetButtonDown("interaction"))
        {
            Debug.Log("Coges el arma");
            GameManager.instance.isWeapon = false;
            Destroy(gameObject);
        }

    }
}
