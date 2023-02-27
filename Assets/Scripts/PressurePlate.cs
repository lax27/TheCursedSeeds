using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject currentPlant;
    private Renderer myRenderer;
    public GameObject secondPlant;
    public Renderer myRenderer2;
  
    void Start()
    {

        // Disable the Renderer component when the script starts.
        currentPlant = GameObject.Find("plant_test");
        secondPlant = GameObject.Find("plant_2");
      

        myRenderer = currentPlant.GetComponent<Renderer>();
        myRenderer2 = secondPlant.GetComponent<Renderer>();

        myRenderer.enabled = false;
        myRenderer2.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        myRenderer.enabled = false;
        if (other.gameObject.CompareTag("Player"))
        {
            myRenderer2.enabled = true;
  

            // Code to execute when the player steps on the pressure plate
            Debug.Log("Something with the tag player is on top of me");

        }
    }
}
