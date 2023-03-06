using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private GameObject[] enemys;
    private List<ChargerMove> chs;
    int sceneID = 1;
    public int deadBug = 0;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(deadBug);
        if(deadBug == 4)
        {
            SceneManager.LoadScene(sceneID);
        }
    }
}
