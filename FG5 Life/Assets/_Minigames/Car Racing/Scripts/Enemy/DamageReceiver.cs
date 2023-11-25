using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public int hp = 1;
    public virtual void Receive(int damage)
    {
        this.hp -= damage;
    }

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
}
