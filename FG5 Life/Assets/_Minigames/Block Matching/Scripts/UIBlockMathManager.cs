using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIBlockMathManager : MonoBehaviour
{
    // singleton
    public static UIBlockMathManager Instance { get; private set; }
    public TextMeshProUGUI ScoreTxt { get => scoreTxt; set => scoreTxt = value; }
    public GameObject StartPanel { get => startPanel; set => startPanel = value; }
    public GameObject GameOverPanel { get => gameOverPanel; set => gameOverPanel = value; }
    public GameObject GameCompletePanel { get => gameCompletePanel; set => gameCompletePanel = value; }

    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameCompletePanel;

    void Awake()
    {
        Instance = this;
        this.startPanel.SetActive(true);
    }
}
