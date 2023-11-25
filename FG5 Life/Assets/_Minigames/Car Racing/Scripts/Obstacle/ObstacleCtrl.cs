using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCtrl : MonoBehaviour
{
    public CarDesSpawner desSpawner;
    public ObstacleDameReceiver obstacleDameReceiver;
    private void Awake()
    {
        this.desSpawner = GetComponent<CarDesSpawner>();
        this.obstacleDameReceiver = GetComponent<ObstacleDameReceiver>();
    }
}
