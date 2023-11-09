using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_StatePlayer : ScriptableObject
{
    [SerializeField] private int percentEatState;
    [SerializeField] private int percentToiletState;
    [SerializeField] private int percentSleepState;

    [SerializeField] private float timerEat;
    [SerializeField] private float timerToilet;
    [SerializeField] private float timerSleep;


    public int PercentEatState { get => percentEatState; set => percentEatState = value; }
    public int PercentToiletState { get => percentToiletState; set => percentToiletState = value; }
    public int PercentSleepState { get => percentSleepState; set => percentSleepState = value; }
    public float TimerEat { get => timerEat; set => timerEat = value; }
    public float TimerToilet { get => timerToilet; set => timerToilet = value; }
    public float TimerSleep { get => timerSleep; set => timerSleep = value; }

}
