using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class button_responsive : MonoBehaviour
{
    public TMP_Text text;
    public int seed_number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.instance.inventory[seed_number].ToString();
        if(GameManager.instance.inventory[seed_number] >= 64)
        {
            GameManager.instance.inventory[seed_number] = 64;
        }
    }

    public void Plant()
    {
        if (GameManager.instance.isPlanted == false)
        {
            //seed - 1 
            if (GameManager.instance.inventory[seed_number] <= 0)
            {
                GameManager.instance.inventory[seed_number] = 0;
            }
            else
            {
                GameManager.instance.inventory[seed_number]--;
            }
            //call function
            GameManager.instance.GrowingPlant(seed_number);
        }
        else 
        { 
            //mostrar dialog que ya hay una planta y que no podes plantar, o mostrar dialog de que hay una planta quieres destuirla para poner una nueva
        }
    }
}
