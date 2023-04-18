using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    public List<Image> lifes;
    PlayerStats ps;
    //private PlayerManager player;
    public Material vacio;
    public Material lleno;

    ///////
    public int a;
    public TMP_Text cooldown;
    public GameObject p;

    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("mantee_ve");
        ps = p.GetComponent<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {
   
        cooldown.text = a.ToString();
    }

    public void UpdateLife()
    {
        for (int i = 0; i < lifes.Count; i++)
        {
            if (i < ps.life)
            {
                lifes[i].material = lleno;
            }
            else
            {
                lifes[i].material = vacio;
            }
        }
    }
}
