using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    // singleton
    public static UIManager Instance { get; private set; }
    public Image EatCirCleImg { get => eatCirCleImg; set => eatCirCleImg = value; }
    public Image ToiletCirCleImg { get => toiletCirCleImg; set => toiletCirCleImg = value; }
    public Image SleepCircleImg { get => sleepCircleImg; set => sleepCircleImg = value; }
    public GameObject PlayerInWc { get => playerInWc; set => playerInWc = value; }

    void Awake()
    {
        Instance = this;
    }

    [SerializeField] private TextMeshProUGUI percentEatTxt;
    [SerializeField] private TextMeshProUGUI percentToiletTxt;
    [SerializeField] private TextMeshProUGUI percentSleepTxt;

    [SerializeField] private TextMeshProUGUI budGetTxt;
    [SerializeField] private TextMeshProUGUI budGetInShopTxt;

    // circle slider
    [SerializeField] private Image eatCirCleImg;
    [SerializeField] private Image toiletCirCleImg;
    [SerializeField] private Image sleepCircleImg;

    [SerializeField] private GameObject sleepPanel;
    [SerializeField] private GameObject playerInWc;

    private void Start()
    {
        SetBudgetTxt();
        SetStateSlider();
    }

    public void SetSleepPanelActive(bool state)
    {
        this.sleepPanel.SetActive(state);
    }

    public void SetStateSlider()
    {
        if (Player.Instance == null) return;
        float eatProgress = (float)Player.Instance.SO_StatePlayer.PercentEatState / 100;
        this.eatCirCleImg.fillAmount = eatProgress;

        float toiletProgress = (float)Player.Instance.SO_StatePlayer.PercentToiletState / 100;
        this.toiletCirCleImg.fillAmount = toiletProgress;

        float sleepProgress = (float)Player.Instance.SO_StatePlayer.PercentSleepState / 100;
        this.sleepCircleImg.fillAmount = sleepProgress;
    }


    public void SetBudgetTxt()
    {
        if (Inventory.Instance == null) return; 
        if (budGetInShopTxt != null)
            budGetInShopTxt.text = Inventory.Instance.SO_Inventory.Budget.ToString();
        if(budGetTxt != null)
            budGetTxt.text = Inventory.Instance.SO_Inventory.Budget.ToString();
    }

    public void SetPercentEatTxt(string percent)
    {
        percentEatTxt.text = percent;
    }

    public void SetPercentToiletTxt(string percent)
    {
        percentToiletTxt.text = percent;
    }

    public void SetPercentSleepTxt(string percent)
    {
        percentSleepTxt.text = percent;
    }

    public void OnLoadHomePage()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void OnLoadGroceryPage()
    {
        SceneManager.LoadScene("GroceryScene", LoadSceneMode.Single);
    }

    public void OnLoadSchoolPage()
    {
        SceneManager.LoadScene("BlockMatchingScene", LoadSceneMode.Single);
    }

    public void OnLoadHospitalPage()
    {
        SceneManager.LoadScene("HospitalScene", LoadSceneMode.Single);
    }

    public void OnLoadElectronicPage()
    {
        SceneManager.LoadScene("ElectronicScene", LoadSceneMode.Single);
    }

    public void OnLoadParkPage()
    {
        SceneManager.LoadScene("CarGameScene", LoadSceneMode.Single);
    }

    public void OnLoadNeighborPage()
    {
        SceneManager.LoadScene("NeighborScene", LoadSceneMode.Single);
    }

    // Home

    public void OnLoadEatScene()
    {
        SceneManager.LoadScene("EatScene", LoadSceneMode.Single);
    }

    public void OnLoadToiletScene()
    {
        Player.Instance.IsAtToiletRoom = true;
        SceneManager.LoadScene("ToiletScene", LoadSceneMode.Single);
    }

    public void OnLoadSleepScene()
    {
        SceneManager.LoadScene("SleepScene", LoadSceneMode.Single);
    }
}
