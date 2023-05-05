using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoom : MonoBehaviour
{
    public GameObject Secret_Room;
    // Start is called before the first frame update
    void Start()
    {
        Secret_Room.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Secret_Room.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Secret_Room.SetActive(false);
    }
}
