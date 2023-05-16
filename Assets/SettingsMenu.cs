using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    public TMP_Text livesAmountText;
    public int livesAmountNum = 3;
    public GameObject rightArrowButtonUI;
    public GameObject leftArrowButtonUI;


    public void GameLivesUp()
    {
        //si la cantidad de vidas es inferior a 7 suma 2
        //si la cantidad de vidas es igual o superior a 7 desactiva el componente
        livesAmountNum += 2;
        leftArrowButtonUI.SetActive(true);

        if (livesAmountNum >= 7)
        {
            livesAmountNum = 7;
            rightArrowButtonUI.SetActive(false);
        }
        GameManager.instance.maxLives=livesAmountNum;
        livesAmountText.text = livesAmountNum + " Lives";
    
    }


    public void GameLivesDown()
    {
        //si la cantidad de vidas no es igual a 3 resta 2
        //si la cantidad de vidas es igual o inferior a 3 desactiva el componente
        livesAmountNum -= 2;
        rightArrowButtonUI.SetActive(true);

        if (livesAmountNum <= 3)
        {
            livesAmountNum = 3;
            leftArrowButtonUI.SetActive(false);
        }
        GameManager.instance.maxLives = livesAmountNum;
        livesAmountText.text = livesAmountNum + " Lives";
    
    }


    public void BackToMenu()
    {
        settingsMenu.SetActive(false);
    }
}
