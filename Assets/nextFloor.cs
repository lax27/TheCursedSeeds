using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextFloor : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //juego fina: abrir menu donde poder volver al hub o continuar

            GameManager.instance.currentFloor++;
            //2 = GameplayDefinitivoTest
            SceneManager.LoadScene("2");
        }

    }
}
