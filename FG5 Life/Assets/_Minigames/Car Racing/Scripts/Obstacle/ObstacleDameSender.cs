using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDameSender : DamageSender
{
    [Header("Damage Obstacle")]
    protected ObstacleCtrl obstacleCtrl;

    private void Awake()
    {
        this.obstacleCtrl = GetComponent<ObstacleCtrl>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Collide with " + collision.gameObject.name);
        if (!collision.CompareTag("Player")) return;

        this.ColliderSendDamage(collision);
    }

    protected override void ColliderSendDamage(Collider2D collision)
    {
        //print("collide in enemy " + this.gameObject.name);
        this.obstacleCtrl.obstacleDameReceiver.Receive(this.dame);
        base.ColliderSendDamage(collision);
    }
}
