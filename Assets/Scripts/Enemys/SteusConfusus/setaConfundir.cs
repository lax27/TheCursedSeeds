using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setaConfundir : MonoBehaviour
{
    public Collider2D cl;
    GameObject palyer;
    PlayerStatus st;
    public float timeconfused = 2;
    private float cofusedTime = 2;
    bool confused = false;
    // Start is called before the first frame update
    void Start()
    {
        palyer = GameObject.Find("mantee_V2");
        

    }

    // Update is called once per frame
    void Update()
    {
        if (confused) {
            cofusedTime -= Time.deltaTime;   
        }
        if(cofusedTime <= 0) {

            st.isConfused = false;
            confused = false;
            cofusedTime = timeconfused;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            st = collision.GetComponent<PlayerStatus>();
            if (!st.isConfused)
            {
                st.isConfused = true;
                confused = true;
            }

        }
    }
}
