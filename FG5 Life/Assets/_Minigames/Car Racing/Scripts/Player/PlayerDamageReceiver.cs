using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    public override void Receive(int damage)
    {
        base.Receive(damage);
        if (this.IsDead())
        {
            CarPlayerCtrl.intance.playerStatus.Dead();
            CarPlayerCtrl.intance.IsDead = true;
            // display Game Over Panel
            CarGameManager.intance.GameOver();
        }
    }
}
