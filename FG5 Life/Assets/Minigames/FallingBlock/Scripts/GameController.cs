using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject startGameScreen;
    // singleton
    public static GameController Instance { get; private set; }

    private bool isGameRunning = false;
    public bool IsGameRunning { get => isGameRunning; set => isGameRunning = value; }
    public int Score { get => score; set => score = value; }
    public int GoalScore { get => goalScore; set => goalScore = value; }

    private int score;

    [SerializeField] private int goalScore = 30;

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            this.isGameRunning = true;
            this.startGameScreen.SetActive(false);
        }
    }

}
