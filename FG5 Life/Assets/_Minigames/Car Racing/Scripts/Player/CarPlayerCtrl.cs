using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlayerCtrl : MonoBehaviour
{
    static public CarPlayerCtrl intance; // sgt

    public DamageReceiver damageReceiver;
    public CarPlayerStatus playerStatus;

    private bool isDead = false;

    public bool IsDead { get => isDead; set => isDead = value; }

    private void Awake()
    {
        CarPlayerCtrl.intance = this; // sgt
        this.damageReceiver = GetComponent<DamageReceiver>();
        this.playerStatus = GetComponent<CarPlayerStatus>();
    }
}
