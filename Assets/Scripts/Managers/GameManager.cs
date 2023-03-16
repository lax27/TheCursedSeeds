using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public enum Wseeds {RABBIT,ICEHEART,LAST};

    public int[] inventory = new int[(int)Wseeds.LAST];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("WARNING: multiple" + this + "in scene!");
            Destroy(this);
        }
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
