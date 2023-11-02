using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RequirementPlayer))]
public class Player : MonoBehaviour
{
    // singleton
    public static Player Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    private ReqPlayerState curState;
    public ReqPlayerState CurState
    {
        get { return this.curState; }
        set { this.curState = value; }
    }
    //private RequirementPlayer reqPlayer;

    private LivingState eatState;
    private LivingState toiletState;
    private LivingState sleepState;

    private void Start()
    {
        /*this.reqPlayer = GetComponent<RequirementPlayer>();

        // test
        this.reqPlayer.CreateState();
        this.curState = this.reqPlayer.GetState();
        print(this.curState);*/

        // test with init solid valid
        // max percent state follow to level player
        // set after that
        this.eatState = new LivingState(100, ReqPlayerState.eat);
        this.toiletState = new LivingState(150, ReqPlayerState.toilet);
        this.sleepState = new LivingState(200, ReqPlayerState.sleep);
    }

    public void Eatting()
    {
        // test with solid valid with 3
        this.eatState.Percent += 3;
        print(this.eatState.Percent);
    }
}

public struct LivingState
{
    private int percent;
    public int Percent
    {
        get { return percent; }
        set { percent = value; }
    }

    private ReqPlayerState nameState;
    public ReqPlayerState NameState
    {
        get { return nameState; }
        set { nameState = value; }
    }


    public LivingState(int percent, ReqPlayerState nameState)
    {
        this.percent = percent;
        this.nameState = nameState;
    }
}
