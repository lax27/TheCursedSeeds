using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneManagement : MonoBehaviour
{
int sceneID = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneID);

            Debug.Log("Something with the tag player is on top of me");

        }
    }
}
