using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{

    public void MenuSelect(GameObject menu)
    {
        menu.SetActive(true);
    }
    public void CloseTab(GameObject tab)
    {
        tab.SetActive(false);
    }

    public void SellSeeds(int goldAmount, int idSeed)
    {
        if (GameManager.instance.inventory[idSeed] < 0)
        {
            GameManager.instance.inventory[idSeed]--;
            GameManager.instance.money = goldAmount;
        }
        else
        {
            return;
        }
    }

    //bug anque no se vende la semilla se recivira el oro igualmente, solucion: usar la funcion de arriva problema no aparece en unity.

    public void ReciveGold(int goldAmount)
    {
        GameManager.instance.money += goldAmount;
    }
    public void IdSeed(int idSeed)
    {
        if (GameManager.instance.inventory[idSeed] > 0)
        {
            GameManager.instance.inventory[idSeed]--;
        }
        else
        {
            return;
        }
    }


    public void ReturnToHub(GameObject gameObject)
    {
        GameObject player = GameObject.Find("mantee_v2");
        player.SetActive(true);
        gameObject.SetActive(false);
    }
}
