using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    private GameObject intreactionZone;
    private GameObject rotationZone;
    private PlantZone pl;
    public int NumChild;
    // Start is called before the first frame update
    void Start()
    {
        rotationZone = GameObject.Find("RotatePoint");
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
            rotationZone.transform.GetChild(0).gameObject.SetActive(false);
            rotationZone.transform.GetChild(NumChild).gameObject.SetActive(true);
            GameManager.instance.currentWeaponID = NumChild;
            Destroy(gameObject);
      }
    }
}
