using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMinimap : MonoBehaviour
{
    [SerializeField] private GameObject minimap;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        minimap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isActive)
        {
            isActive = true;
            minimap.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && isActive)
        {
            isActive = false;
            minimap.SetActive(false);
        }
    }
}