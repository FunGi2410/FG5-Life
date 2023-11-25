using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarGameManager : MonoBehaviour
{
    // sgt
    static public CarGameManager intance;

    [SerializeField] private int rankPlayer = 0;
    [SerializeField] private int rankGoal = 3;
    [SerializeField] private EnemySpawner enemySpawner;

    private bool isGameOver = false;
    private bool isGameRunning = false;

    private float timer;
    [SerializeField] private float timeRacing = 60;

    public float Timer { get => timer; set => timer = value; }
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }
    public bool IsGameRunning { get => isGameRunning; set => isGameRunning = value; }

    private void Awake()
    {
        CarGameManager.intance = this;

        GameObject musicObj = GameObject.FindGameObjectWithTag("MusicBase");
        Destroy(musicObj);
    }

    /*private void Start()
    {
        StartCoroutine(this.CounterTime());
    }*/

    private void Update()
    {
        this.RankOfPlayer();
    }

    IEnumerator CounterTime()
    {
        while (true)
        {
            CarUIManager.intance.TimerTxt.text = "Time: " + this.timer.ToString();
            this.timer++;
            if (this.timer >= this.timeRacing) break;
            if (!isGameRunning || isGameOver) break;
            yield return new WaitForSeconds(1f);
        }

        this.GameOver();
        StopCoroutine(this.CounterTime());
    }

    void CompleteGame()
    {
        // set active game complete panel
        CarUIManager.intance.gameCompletePanel.SetActive(true);

        Inventory.Instance.Budget += 100;
        Inventory.Instance.SO_Inventory.Budget = Inventory.Instance.Budget;
    }

    void DontCompleteGame()
    {
        // set active game over panel
        CarUIManager.intance.gameOverPanel.SetActive(true);
    }

    public virtual void GameOver()
    {
        this.isGameOver = true;
        this.isGameRunning = false;

        if (!CarPlayerCtrl.intance.IsDead && this.rankPlayer <= this.rankGoal) this.CompleteGame();
        else this.DontCompleteGame();
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnStartGame()
    {
        this.isGameRunning = true;
        StartCoroutine(this.CounterTime());
        CarUIManager.intance.gameStartPanel.SetActive(false);
    }

    public void RankOfPlayer()
    {
        int counter = this.enemySpawner.Objs.Count;
        if (this.enemySpawner.Objs != null)
        {
            foreach (GameObject enemy in this.enemySpawner.Objs)
            {
                if(enemy != null)
                {
                    if (CarPlayerCtrl.intance.transform.position.y > enemy.transform.position.y)
                    {
                        counter--;
                    }
                }
            }
            this.rankPlayer = counter + 1;
            CarUIManager.intance.RankTxt.text = "Rank: " + this.rankPlayer.ToString();
        }
    }
}
