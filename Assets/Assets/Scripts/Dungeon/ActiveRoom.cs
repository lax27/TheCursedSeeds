using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRoom : MonoBehaviour
{
    public GameObject enemiesParent;
    public GameObject parentAdjacentRoomsSpawnPositions;
    public GameObject unknown;
    private BoxCollider2D col;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemiesParent.transform.childCount; i++)
        {
            Transform enemyTransform = enemiesParent.transform.GetChild(i);
            enemyTransform.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesParent.transform.childCount <= 0)
        {
            for(int i = 0; i < parentAdjacentRoomsSpawnPositions.transform.childCount; i++)
            {
                col = parentAdjacentRoomsSpawnPositions.transform.GetChild(i).GetComponent<BoxCollider2D>();
                col.enabled = true;
                animator = parentAdjacentRoomsSpawnPositions.transform.GetChild(i).GetComponent<Animator>();
                animator.enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < parentAdjacentRoomsSpawnPositions.transform.childCount; i++)
            {
                col = parentAdjacentRoomsSpawnPositions.transform.GetChild(i).GetComponent<BoxCollider2D>();
                animator = parentAdjacentRoomsSpawnPositions.transform.GetChild(i).GetComponent<Animator>();

                if (col.enabled == false && animator.enabled == false)
                {
                    //Debug.Log("Already on");
                }
                else
                {
                    col.enabled = false;
                    animator.enabled = false;
                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < enemiesParent.transform.childCount; i++)
            {
                enemiesParent.transform.GetChild(i).gameObject.SetActive(true);
            }

            Destroy(unknown);
        }
    }
}
