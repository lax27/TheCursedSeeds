using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShowDescription : MonoBehaviour
{ 
    [SerializeField] private GameObject Description;
    [SerializeField] private GameObject mantee;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private GameObject exclamation;

    private bool isPlayerInRange;




    // Start is called before the first frame update
    void Start()
    {
        mantee = GameObject.Find("mantee_v2");
        movement = mantee.GetComponent<PlayerMovement>();
    }
    private void Show()
    {
        Description.SetActive(true);
        movement.enabled = false;
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Ready");
            Show();
        }

        if (isPlayerInRange && Input.GetButtonDown("Cancel"))
        {
            Description.SetActive(false);
            movement.enabled = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            exclamation.SetActive(true);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;

        }
    }

 
}
