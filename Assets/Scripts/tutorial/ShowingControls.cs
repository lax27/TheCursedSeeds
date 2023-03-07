using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowingControls : MonoBehaviour
{
    [SerializeField] private GameObject Description;
    [SerializeField] private GameObject exclamation;

    private bool isPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            Description.SetActive(true);
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
            exclamation.SetActive(false);

        }
    }


}
