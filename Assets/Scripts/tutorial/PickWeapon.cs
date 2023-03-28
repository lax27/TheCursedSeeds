using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickWeapon : MonoBehaviour
{
    public GameObject weapon;
    public GameObject exclamation;
    public GameObject preWeapon;
    private bool isPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        preWeapon.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("interaction"))
        {
            Destroy(weapon);
            Destroy(exclamation);
            preWeapon.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
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
