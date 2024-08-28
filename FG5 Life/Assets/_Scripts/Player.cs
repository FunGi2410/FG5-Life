using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // singleton
    public static Player Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    private bool isAtToiletRoom = false;

    // timer
    private float eatTimer = 0f;
    private float toiletTimer = 0f;
    private float sleepTimer = 0f;
    private float timeDuration = 60f;

    private bool isSleep = false;
    private bool isToilet = false;

    private int decline = 10;

    private ReqPlayerState curState;
    public ReqPlayerState CurState
    {
        get { return this.curState; }
        set { this.curState = value; }
    }

    public SO_StatePlayer SO_StatePlayer { get => sO_StatePlayer; set => sO_StatePlayer = value; }
    public bool IsSleep { get => isSleep; set => isSleep = value; }
    public bool IsAtToiletRoom { get => isAtToiletRoom; set => isAtToiletRoom = value; }
    public bool IsToilet { get => isToilet; set => isToilet = value; }

    private LivingState eatState;
    private LivingState toiletState;
    private LivingState sleepState;

    [SerializeField] private SO_StatePlayer sO_StatePlayer;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "ToiletScene") this.isAtToiletRoom = true;

        // max percent state follow to level player
        // set after that
        this.SetCurState();
    }

    private void Update()
    {
        this.DeclineState();
    }

    // percent decrease over time
    public void DeclineState()
    {
        // Eat state
        if (Timer.IsCounter(ref this.eatTimer, this.timeDuration))
        {
            this.eatState.Percent -= this.decline;

            // set so data
            SO_StatePlayer.PercentEatState = eatState.Percent;

            float progress = (float)this.eatState.Percent / 100;
            UIManager.Instance.EatCirCleImg.fillAmount = progress;
        }
        this.eatState.Timer = this.eatTimer;
        SO_StatePlayer.TimerEat = this.eatState.Timer;

        // Toilet state
        if (Timer.IsCounter(ref this.toiletTimer, this.timeDuration))
        {
            this.toiletState.Percent -= this.decline;

            // set so data
            SO_StatePlayer.PercentToiletState = toiletState.Percent;

            float progress = (float)this.toiletState.Percent / 100;
            UIManager.Instance.ToiletCirCleImg.fillAmount = progress;
        }
        this.toiletState.Timer = this.toiletTimer;
        SO_StatePlayer.TimerToilet = this.toiletState.Timer;

        // sleep state
        if (Timer.IsCounter(ref this.sleepTimer, this.timeDuration))
        {
            this.sleepState.Percent -= this.decline;

            // set so data
            SO_StatePlayer.PercentSleepState = sleepState.Percent;

            float progress = (float)this.sleepState.Percent / 100;
            UIManager.Instance.SleepCircleImg.fillAmount = progress;
        }
        this.sleepState.Timer = this.sleepTimer;
        SO_StatePlayer.TimerSleep = this.sleepState.Timer;
    }

    public void SetCurState()
    {
        this.eatState = new LivingState(SO_StatePlayer.PercentEatState, ReqPlayerState.eat, SO_StatePlayer.TimerEat);
        this.toiletState = new LivingState(SO_StatePlayer.PercentToiletState, ReqPlayerState.toilet, SO_StatePlayer.TimerToilet);
        this.sleepState = new LivingState(SO_StatePlayer.PercentSleepState, ReqPlayerState.sleep, SO_StatePlayer.TimerSleep);

        this.eatTimer = SO_StatePlayer.TimerEat;
        this.toiletTimer = SO_StatePlayer.TimerToilet;
        this.sleepTimer = SO_StatePlayer.TimerSleep;
    }

    public void SetStateDataSO()
    {
        SO_StatePlayer.PercentEatState = eatState.Percent;
        SO_StatePlayer.PercentToiletState = toiletState.Percent;
        SO_StatePlayer.PercentSleepState = sleepState.Percent;

        SO_StatePlayer.TimerEat = eatState.Timer;
        SO_StatePlayer.TimerToilet = toiletState.Timer;
        SO_StatePlayer.TimerSleep = sleepState.Timer;
    }

    public void Eatting()
    {
        // test with solid valid with 3
        this.eatState.Percent += 15;

        // set percent eat state ui
        float progress = (float)this.eatState.Percent / 100;
        UIManager.Instance.EatCirCleImg.fillAmount = progress;

        // set so data
        SO_StatePlayer.PercentEatState = eatState.Percent;
    }

    public void GoingToilet()
    {
        StartCoroutine(GoingToiletCoroutine());
    }

    IEnumerator GoingToiletCoroutine()
    {
        int counter = 0;
        for (; ; )
        {
            if(counter++ >= 10)
            {
                print("Done Toilet");
                this.isToilet = false;
                this.toiletState.Percent = 100;

                SceneManager.LoadScene("ToiletScene", LoadSceneMode.Single);

                // set percent eat state ui
                float progress = (float)this.toiletState.Percent / 100;
                UIManager.Instance.ToiletCirCleImg.fillAmount = progress;

                // set so data
                SO_StatePlayer.PercentToiletState = toiletState.Percent;
                StopCoroutine(GoingToiletCoroutine());
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void Sleeping()
    {
        StartCoroutine(SleepingCoroutine());
    }

    IEnumerator SleepingCoroutine()
    {
        int counter = 0;
        for (; ; )
        {
            if(!this.isSleep)
            {
                StopCoroutine(SleepingCoroutine());
                break;
            }

            counter++;

            this.sleepState.Percent += 20;

            // set percent eat state ui
            float progress = (float)this.sleepState.Percent / 100;
            UIManager.Instance.SleepCircleImg.fillAmount = progress;

            // set so data
            SO_StatePlayer.PercentSleepState = sleepState.Percent;

            print("Counter Sleep: " + counter);
            yield return new WaitForSeconds(3f);
        }
    }
}

public enum ReqPlayerState
{
    eat,
    sleep,
    toilet
}

public struct LivingState
{
    private int percent;
    public int Percent
    {
        get { return percent; }
        set {
            if (value <= 0) percent = 0;
            else if (value >= 100) percent = 100;
            else percent = value; 
        }
    }

    private ReqPlayerState nameState;
    public ReqPlayerState NameState
    {
        get { return nameState; }
        set { nameState = value; }
    }

    private float timer;
    public float Timer
    {
        get { return timer; }
        set { timer = value; }
    }


    public LivingState(int percent, ReqPlayerState nameState, float timer)
    {
        this.percent = percent;
        this.timer = timer;
        this.nameState = nameState;
    }
}
