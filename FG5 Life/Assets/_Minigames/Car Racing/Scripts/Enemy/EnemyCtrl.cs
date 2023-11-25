using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public CarDesSpawner desSpawner;
    public EnemyDamageReceiver enemyDamageReceiver;
    private void Awake()
    {
        this.desSpawner = GetComponent<CarDesSpawner>();
        this.enemyDamageReceiver = GetComponent<EnemyDamageReceiver>();
    }
}
