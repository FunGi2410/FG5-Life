using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void OnEattingBnt()
    {
        Player.Instance.Eatting();
    }

    public void OnGoingToilet()
    {
        if(Player.Instance.IsAtToiletRoom && Player.Instance.SO_StatePlayer.PercentToiletState <= 30 && !Player.Instance.IsToilet)
        {
            Player.Instance.IsToilet = true;
            Player.Instance.transform.position = new Vector2(-100, 0);
            UIManager.Instance.WcImg_0.gameObject.SetActive(false);
            UIManager.Instance.WcImg_1.gameObject.SetActive(true);
            Player.Instance.GoingToilet();
        }
    }

    private void Update()
    {
        this.OnGoingToilet();
    }

    public void OnSleepingBnt()
    {
        Player.Instance.IsSleep = !Player.Instance.IsSleep;
        if (Player.Instance.IsSleep)
        {
            UIManager.Instance.SetSleepPanelActive(Player.Instance.IsSleep);
            Player.Instance.transform.position = new Vector2(-100, 0);
        }
        else
        {
            UIManager.Instance.SetSleepPanelActive(Player.Instance.IsSleep);
            Player.Instance.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -119);
        }
        Player.Instance.Sleeping();
    }

    // Load Scene
    // Menu
    public void OnLoadMenuPage()
    {
        Player.Instance.IsAtToiletRoom = false;
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
