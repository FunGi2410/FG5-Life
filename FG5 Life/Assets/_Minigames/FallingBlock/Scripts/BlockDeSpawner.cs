using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDeSpawner : MonoBehaviour
{
    private float screenHalfHeightInWorldUnits;
    private void Start()
    {
        this.screenHalfHeightInWorldUnits = Camera.main.orthographicSize;

        float obstacleHeight = transform.localScale.y;
        this.screenHalfHeightInWorldUnits += obstacleHeight;
    }

    private void Update()
    {
        this.DeSpawnObj();
    }

    protected virtual void DeSpawnObj()
    {
        if(transform.position.y < -this.screenHalfHeightInWorldUnits)
        {
            Destroy(gameObject);
        }
    }
}
