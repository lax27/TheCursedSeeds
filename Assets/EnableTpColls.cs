using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTpColls : MonoBehaviour
{
    [SerializeField] private Collider2D tpCol2D;
    // Start is called before the first frame update
    void Start()
    {
        tpCol2D = GameObject.Find("dungeonTp").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tpCol2D.enabled = true;
    }
}
