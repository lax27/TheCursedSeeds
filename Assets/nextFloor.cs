using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //para el juego final:
            //SceneManager.LoadScene("GameplayDefinitivoTest");

            //para la demo:
            SceneManager.LoadScene("HUB_HUB");
        }

    }
}
