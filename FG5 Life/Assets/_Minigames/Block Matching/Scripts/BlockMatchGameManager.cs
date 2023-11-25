using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockMatchGameManager : MonoBehaviour
{
    // singleton
    public static BlockMatchGameManager Instance { get; private set; }
    public int Score { get => score; set => score = value; }
    public bool IsGameRunning { get => isGameRunning; set => isGameRunning = value; }
    public int GoalScore { get => goalScore; set => goalScore = value; }

    private int score = 0;
    [SerializeField] private int goalScore = 10;
    private bool isGameRunning = false;

    void Awake()
    {
        Instance = this;

        GameObject musicObj = GameObject.FindGameObjectWithTag("MusicBase");
        Destroy(musicObj);
    }

    private void Start()
    {
        // set UI
        UIBlockMathManager.Instance.ScoreTxt.text = this.score.ToString();
    }

    public void GameOver()
    {
        this.isGameRunning = false;
        if (this.score >= this.goalScore) this.CompleteGame();
        else this.DontCompleteGame();
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene("BlockMatchingScene", LoadSceneMode.Single);
    }
    public void OnStartGame()
    {
        this.isGameRunning = true;
        UIBlockMathManager.Instance.StartPanel.SetActive(false);
    }

    void CompleteGame()
    {
        UIBlockMathManager.Instance.GameCompletePanel.SetActive(true);
        Inventory.Instance.Budget += 100;
        Inventory.Instance.SO_Inventory.Budget = Inventory.Instance.Budget;
    }

    void DontCompleteGame()
    {
        UIBlockMathManager.Instance.GameOverPanel.SetActive(true);
    }

}
