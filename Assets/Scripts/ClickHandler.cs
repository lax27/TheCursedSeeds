using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public GameObject plantPrefab;
    public int plantCost = 10;
    public int maxPlants = 1;
    private int plantedCount = 0; 
    public GameObject plant;
    private Renderer myRenderer;
    private Renderer myRenderer2;
    public GameObject secondPlant;

    void Start()
    {
        // Disable the Renderer component when the script starts.
        plant = GameObject.Find("plant_test");
        myRenderer = plant.GetComponent<Renderer>();
        myRenderer.enabled = false;

        myRenderer2 = secondPlant.GetComponent<Renderer>();
        myRenderer2.enabled = false;
    }

    private void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {
            if (plantedCount < maxPlants)   
            {
                myRenderer2.enabled = false;
                OnMouseDown();
            }
            else
            {
                return;
            }
        }
    
}
    void OnMouseDown()
    {
        
        plantedCount++;
        myRenderer.enabled = true;
        Debug.Log("You clicked me");
        Debug.Log(plantedCount);
    }

}
