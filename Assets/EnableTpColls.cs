using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTpColls : MonoBehaviour
{
    [SerializeField] private Collider2D tpColl;
    // Start is called before the first frame update
    void Start()
    {
        tpColl = GameObject.Find("dungeonTp").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tpColl.enabled = true;
    }
}
