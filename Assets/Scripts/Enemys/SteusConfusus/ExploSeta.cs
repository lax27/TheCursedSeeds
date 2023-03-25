using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploSeta : MonoBehaviour
{
    GameObject player;
    public GameObject Explo;
    bool isExploating = false;
    PlayerStatus pst;
    Collider2D cl;
    public Collider2D lc;
    public SpriteRenderer sr;
    private float confusedTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mantee_v2");
        cl = GetComponent<Collider2D>();
        pst = player.GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isExploating)
        {
            sr.enabled = false;
            lc.enabled = false;
            Explo.SetActive(true);


            pst.isConfused = true;
            confusedTime -= Time.deltaTime;

        }
        if (confusedTime <= 0)
        {
            Destroy(gameObject);
            pst.isConfused = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isExploating = true;
            sr.enabled = false;
        }
    }
}

