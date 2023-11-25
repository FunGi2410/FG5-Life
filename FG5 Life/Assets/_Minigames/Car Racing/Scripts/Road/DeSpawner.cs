using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawner : MonoBehaviour
{
    private float distance = 0f;

    private void FixedUpdate()
    {
        this.UpdateRoad();
    }

    protected virtual void UpdateRoad()
    {
        distance = Vector2.Distance(CarPlayerCtrl.intance.transform.position, transform.position);
        print(this.name + "Distance: " + distance);
        if (distance >= 70f)
        {
            // 70 is the distance to despawn
            this.DeSpawn();
        }
    }

    protected virtual void DeSpawn()
    {
        Destroy(gameObject);
    }
}
