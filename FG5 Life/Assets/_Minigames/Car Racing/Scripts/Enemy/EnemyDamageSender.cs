using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    [Header("Damage Enemy")]
    protected EnemyCtrl enemyCtrl;

    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Collide with " + collision.gameObject.name);
        if (!collision.CompareTag("Player") && !collision.CompareTag("Bomb")) return;
        
        this.ColliderSendDamage(collision);
    }

    protected override void ColliderSendDamage(Collider2D collision)
    {
        //print("collide in enemy " + this.gameObject.name);
        this.enemyCtrl.enemyDamageReceiver.Receive(this.dame);
        base.ColliderSendDamage(collision);
    }
}
