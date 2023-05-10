using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlayerIcon : MonoBehaviour
{

    public static MinimapPlayerIcon instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;       
    }
}
