using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarUIManager : MonoBehaviour
{
    // sgt
    static public CarUIManager intance;

    public GameObject gameOverPanel;
    public GameObject gameCompletePanel;
    public GameObject gameStartPanel;

    [SerializeField] private TextMeshProUGUI rankTxt;
    [SerializeField] private TextMeshProUGUI timerTxt;

    public TextMeshProUGUI RankTxt { get => rankTxt; set => rankTxt = value; }
    public TextMeshProUGUI TimerTxt { get => timerTxt; set => timerTxt = value; }

    private void Awake()
    {
        CarUIManager.intance = this;

        this.gameOverPanel.SetActive(false);
        this.gameCompletePanel.SetActive(false);
        this.gameStartPanel.SetActive(true);
    }
}
