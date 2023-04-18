using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullSector : MonoBehaviour
{
    public GameObject w;
    public GameObject i;
    private WeaponNull n;
    // Start is called before the first frame update
    void Start()
    {
        n = i.GetComponent<WeaponNull>();
        n.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(w == null)
        {
            n.enabled = true;
        }
    }
}
