using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleObject : MonoBehaviour
{

    public GameObject choosed_plant;
    private CircleCollider2D plant_collider;
    // Start is called before the first frame update
    void Start()
    {
        plant_collider = choosed_plant.GetComponent<CircleCollider2D>();
        choosed_plant.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
