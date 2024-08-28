using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Vector2 originalPosPlayerInBedroom;

    // target for Door to move
    private Vector2 targetOfDoor = new Vector2(-98f, -21.91949f);
    [SerializeField] private GameObject doorObj;
    private float speedOfDoor = 2;


    private void Start()
    {
        if(Player.Instance != null)
            this.originalPosPlayerInBedroom = new Vector2(Player.Instance.GetComponent<RectTransform>().anchoredPosition.x, Player.Instance.GetComponent<RectTransform>().anchoredPosition.y);
    }


   /* public void OnEattingBnt()
    {
        if (Player.Instance == null) return;
        Player.Instance.Eatting();
    }*/

    public void OnGoingToilet()
    {
        if (Player.Instance == null) return;
        if(Player.Instance.IsAtToiletRoom && Player.Instance.SO_StatePlayer.PercentToiletState <= 30 && !Player.Instance.IsToilet)
        {
            Player.Instance.IsToilet = true;
            Player.Instance.GetComponent<RectTransform>().anchoredPosition = new Vector2(-4000, 0);
            if (UIManager.Instance.PlayerInWc != null) UIManager.Instance.PlayerInWc.SetActive(true);
            Player.Instance.GoingToilet();
            StartCoroutine(DoorMovement());
        }
    }

    private void Update()
    {
        if (Player.Instance == null) return;
        this.OnGoingToilet();
    }

    IEnumerator DoorMovement()
    {
        if (this.doorObj != null)
        {
            while (true)
            {
                if (this.doorObj.GetComponent<RectTransform>().anchoredPosition.x <= this.targetOfDoor.x)
                {
                    StopCoroutine(DoorMovement());
                    break;
                }
                var step = this.speedOfDoor; // calculate distance to move
                this.doorObj.GetComponent<RectTransform>().anchoredPosition = Vector3.MoveTowards(
                    this.doorObj.GetComponent<RectTransform>().anchoredPosition,
                    this.targetOfDoor, step);
                yield return new WaitForSeconds(.01f);
            }
        }
    }

    public void OnSleepingBnt()
    {
        Player.Instance.IsSleep = !Player.Instance.IsSleep;
        if (Player.Instance.IsSleep)
        {
            UIManager.Instance.SetSleepPanelActive(Player.Instance.IsSleep);
            Player.Instance.GetComponent<RectTransform>().anchoredPosition = new Vector2(-4000, 0);
        }
        else
        {
            UIManager.Instance.SetSleepPanelActive(Player.Instance.IsSleep);
            Player.Instance.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.originalPosPlayerInBedroom.x, this.originalPosPlayerInBedroom.y);
        }
        Player.Instance.Sleeping();
    }

    // Load Scene
    // Menu
    public void OnLoadMenuPage()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}





    
