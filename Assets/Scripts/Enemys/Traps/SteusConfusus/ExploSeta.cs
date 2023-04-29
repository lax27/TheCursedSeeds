using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploSeta : MonoBehaviour
{
    GameObject player;
    public GameObject Explo;
    public GameObject zone;
    bool isExploding = false;
    PlayerStatus playerStatus;
    public Collider2D cl;
    public SpriteRenderer sr;
    private float confusedTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mantee_v2");
        cl = GetComponent<Collider2D>();
        playerStatus = player.GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isExploding)
        {
            sr.enabled = false;
            cl.enabled = false;
            Explo.SetActive(true);
            Destroy(zone);

            playerStatus.isConfused = true;
            confusedTime -= Time.deltaTime;

        }
        if (confusedTime <= 0)
        {
            Destroy(gameObject);
            playerStatus.isConfused = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isExploding = true;
            sr.enabled = false;
        }
    }
}

