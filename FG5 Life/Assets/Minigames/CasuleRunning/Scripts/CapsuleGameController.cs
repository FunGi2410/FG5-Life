using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CapsuleGameController : MonoBehaviour
{
    private float myScore;
    private bool isGameRunning = false;
    [SerializeField] private int goalScore = 20;
    private bool isGameover = false;
    private CapsuleUIManager myUI;

    public bool IsGameover { get => isGameover; set => isGameover = value; }
    public bool IsGameRunning { get => isGameRunning; set => isGameRunning = value; }

    private void Start()
    {
        myUI = FindObjectOfType<CapsuleUIManager>();
    }
    void Update()
    {
        if (myUI.GetIsShow())
        {
            myUI.ShowStartPanel();
        }
        else
        {
            myUI.ShowStartPanel();
            myUI.ShowScoreText();
        }

        //----------------------------------------//
        if (IsGameover && !this.isGameRunning)
        {
            this.isGameRunning = false;
            if (myScore >= goalScore)
            {
                myUI.CompleteGame();
            }
            else myUI.DontCompleteGame();
            myUI.ShowGameoverPanel(true);
            return;
        }
    }

    // các hàm truy xuất điểm
    public void SetScore(float value)
    {
        myScore = value;
    }

    public float GetScore()
    {
        return myScore;
    }

    public void ScoreIncrement()
    {
        myScore++;
        myUI.SetScoreText("" + myScore);
    }

    // các hàm truy xuất game over
    public void SetGameover(bool state)
    {
        IsGameover = state;
    }

    public bool GetGameover()
    {
        return IsGameover;
    }

    public void Replay()
    {
        SceneManager.LoadScene("HospitalScene");
    }
}


