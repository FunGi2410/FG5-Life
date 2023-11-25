 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    [Header("DamageSender")]
    protected int dame = 1;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        this.ColliderSendDamage(collision);
    }

    protected virtual void ColliderSendDamage(Collider2D collision)
    {
        DamageReceiver damageReceiver = collision.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        damageReceiver.Receive(this.dame);
    }
}
