using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    private GameObject intreactionZone;
    private GameObject rotationZone;
    private PlantZone palntZone;
    public int NumChild;
    // Start is called before the first frame update
    void Start()
    {
        rotationZone = GameObject.Find("RotatePoint");
        intreactionZone = GameObject.Find("interaction");
        palntZone = intreactionZone.GetComponent<PlantZone>();
    }

    // Update is called once per frame
    void Update()
    {
      if(palntZone.inRange && GameManager.instance.isWeapon && Input.GetButtonDown("interaction"))
      {
            Debug.Log("Coges el arma");
            GameManager.instance.isWeapon = false;
            rotationZone.transform.GetChild(0).gameObject.SetActive(false);
            rotationZone.transform.GetChild(NumChild).gameObject.SetActive(true);
            GameManager.instance.currentWeaponID = NumChild;
            Destroy(gameObject);


            for (int i = 0; i < rotationZone.transform.childCount; i++)
            {
                rotationZone.transform.GetChild(i).gameObject.SetActive(false);
            }
            rotationZone.transform.GetChild(NumChild).gameObject.SetActive(true);
        }
    }
}
