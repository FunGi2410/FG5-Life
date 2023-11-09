using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CapsuleUIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameoverPanel;
    public GameObject startPanel;
    public GameObject showScoreText;

    public TextMeshProUGUI announceTxt;
    public TextMeshProUGUI gameOverTxt;

    public void CompleteGame()
    {
        gameOverTxt.text = "Congratulation!!!";
        announceTxt.text = "You are rewarded with 100$";

        Inventory.Instance.Budget += 100;
        Inventory.Instance.SO_Inventory.Budget = Inventory.Instance.Budget;
    }

    public void DontCompleteGame()
    {
        gameOverTxt.text = "Game Over!";
        announceTxt.text = "Please try again!";
    }

    public void SetScoreText (string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }

    public void ShowGameoverPanel(bool isShow)
    {
        if (gameoverPanel)
        {
            gameoverPanel.SetActive(isShow);
        }
    }

    private bool myIsShow;
    public void SetIsShow(bool state)
    {
        myIsShow = state;
    }

    public bool GetIsShow()
    {
        return myIsShow;
    }
    public void ShowStartPanel()
    {
        if (startPanel)
        {
            startPanel.SetActive(myIsShow);
            showScoreText.SetActive(!myIsShow);
        }
    }

    public void ShowScoreText()
    {
        if (showScoreText)
        {
            showScoreText.SetActive(true);
        }
    }
}
