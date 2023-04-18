using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeRoom : MonoBehaviour
{
    public GameObject enemies;
    public GameObject tps;
    private BoxCollider2D col;
    private Animator a;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemies.transform.childCount; i++)
        {
            enemies.transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.transform.childCount <= 0)
        {
            for(int i = 0; i < tps.transform.childCount; i++)
            {
                col = tps.transform.GetChild(i).GetComponent<BoxCollider2D>();
                col.enabled = true;
                a = tps.transform.GetChild(i).GetComponent<Animator>();
                a.enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < tps.transform.childCount; i++)
            {
                col = tps.transform.GetChild(i).GetComponent<BoxCollider2D>();
                a = tps.transform.GetChild(i).GetComponent<Animator>();

                if (col.enabled == false && a.enabled == false)
                {
                    Debug.Log("Already on");
                }
                else
                {
                    col.enabled = false;
                    a.enabled = false;
                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < enemies.transform.childCount; i++)
            {
                enemies.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
