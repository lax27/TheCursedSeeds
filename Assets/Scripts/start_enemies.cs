using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_enemies : MonoBehaviour
{
    //public List<GameObject> enemies = new List<GameObject>();

    //public List<BoxCollider2D> boxCollider2Ds = new List<BoxCollider2D>();
    //public List<Animator> tps = new List<Animator>();
    //public List<bool> enemyDead = new List<bool>();

    //public int nulls;

    //private bool enemiesExecute;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    for (int i = 0; i < enemies.Count; i++)
    //    {
    //        enemies[i].SetActive(false);
    //    }

    //    for(int i = 0; i < boxCollider2Ds.Count; i++)
    //    {
    //        boxCollider2Ds[i].enabled = false;
    //        for(int j = 0; j < tps.Count; j++)
    //        {
    //            tps[j].enabled = false;
    //        }
    //    }

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    for(int i = 0; i < enemyDead.Count; i++)
    //    {
    //        if (enemies[i] == null)
    //        {
    //            enemyDead[i] = true;
    //        }
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{


    //    if (enemies.Count > 0)
    //    {
    //        for (int i = 0; i < enemies.Count; i++)
    //        {
    //            enemies[i].SetActive(true);
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("All enemies executed");
    //    }



    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //    if (enemyDead[4] == true && enemyDead[5] == true)
    //    {
    //        for (int i = 0; i < tps.Count; i++)
    //        {
    //            tps[i].enabled = true;
    //            for (int j = 0; j < tps.Count; j++)
    //            {
    //                boxCollider2Ds[i].enabled = true;
    //            }
    //        }
    //    }
    //}
    public GameObject Enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < Enemies.transform.childCount;i++)
        {
            Enemies.transform.GetChild(i).gameObject.SetActive(true);
        }
    }


}
