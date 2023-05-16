using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploSeta : MonoBehaviour
{
    [SerializeField] GameObject enemies;

    PlayerStatus playerStatus;
    GameObject player;

    public GameObject explosion;
    public GameObject zone;
    public GameObject zone2;
    public Collider2D cl;
    public SpriteRenderer sr;

    private float confusedTime = 5;
    bool isExploding = false;


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
        if (enemies.transform.childCount == 0)
        {
            sr.enabled = false;
            cl.enabled = false;
            explosion.SetActive(true);
            Destroy(zone);
            Destroy(zone2);
            confusedTime -= Time.deltaTime;
        }

        if (isExploding && enemies.transform.childCount != 0)
        {
            sr.enabled = false;
            cl.enabled = false;
            explosion.SetActive(true);
            Destroy(zone);
            Destroy(zone2);

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

