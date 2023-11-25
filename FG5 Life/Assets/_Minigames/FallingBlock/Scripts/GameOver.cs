using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreNumberUI;
    public TextMeshProUGUI announceTxt;
    public TextMeshProUGUI gameOverTxt;
    bool isGameOver = false;

    private void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath += this.OnGameOver;
    }

    private void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GroceryScene", LoadSceneMode.Single);
            }
        }
    }

    public void OnGameOver()
    {
        isGameOver = true;
        GameController.Instance.Score = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        scoreNumberUI.text = GameController.Instance.Score.ToString();
        if (GameController.Instance.Score >= GameController.Instance.GoalScore) this.CompleteGame();
        else this.DontCompleteGame();
        gameOverScreen.SetActive(true);
    }

    void CompleteGame()
    {
        Inventory.Instance.Budget += 100;
        Inventory.Instance.SO_Inventory.Budget = Inventory.Instance.Budget;
        this.gameOverTxt.text = "Congratulation!!!";
        this.announceTxt.text = "You are rewarded with 100$";
    }

    void DontCompleteGame()
    {
        this.gameOverTxt.text = "Game Over";
        this.announceTxt.text = "Please try again!";
    }
}
