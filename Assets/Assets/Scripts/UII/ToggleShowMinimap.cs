using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShowMinimap : MonoBehaviour
{
    public GameObject minimap;
    // Start is called before the first frame update
    void Start()
    {
        minimap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && minimap.active)
        {
            minimap.SetActive(false);
        }

        else if(Input.GetKeyDown(KeyCode.Tab) && !minimap.active)
        { 
            minimap.SetActive(true);
        }


    }
}
