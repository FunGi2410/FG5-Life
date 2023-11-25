using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDameReceiver : DamageReceiver
{
    protected ObstacleCtrl obstacleCtrl;

    private void Awake()
    {
        this.obstacleCtrl = GetComponent<ObstacleCtrl>();
    }
    public override void Receive(int damage)
    {
        base.Receive(damage);
        if (this.IsDead())
        {
            EffectManager.instance.SpawnVFX("Explosion_B", transform.position, transform.rotation);
            this.obstacleCtrl.desSpawner.Despawn();
        }
    }
}
