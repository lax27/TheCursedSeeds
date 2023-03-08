using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCropManager : MonoBehaviour
{
    private GameObject Rabbit_P, Heart_P;
    private SeedPlant SeedPlant;
    // Start is called before the first frame update
    void Start()
    {
        Heart_P = GameObject.Find("heart-plant");
        Rabbit_P = GameObject.Find("rabbit-plant");

    }

    // Update is called once per frame
    void Update()
    {
        if (Heart_P != null)
        {
            SeedPlant = Heart_P.GetComponent<SeedPlant>();
        }
   
        if (Rabbit_P != null)
        {
            SeedPlant = Rabbit_P.GetComponent<SeedPlant>();
        }

        if (SeedPlant.Heart == false)
        {
            Debug.Log("hola abuela");
        }
        
    }
}
