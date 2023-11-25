using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    protected EnemyCtrl enemyCtrl;

    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }
    public override void Receive(int damage)
    {
        base.Receive(damage);
        if (this.IsDead())
        {
            EffectManager.instance.SpawnVFX("Explosion_B", transform.position, transform.rotation);
            this.enemyCtrl.desSpawner.Despawn();
        }
    }
}
