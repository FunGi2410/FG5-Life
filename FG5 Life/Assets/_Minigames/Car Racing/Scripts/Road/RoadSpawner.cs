using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject roadPrefab;
    [SerializeField] protected GameObject roadSpawnPos;
    [SerializeField] protected GameObject roadCurrent;

    private float distance = 0f;

    private void Update()
    {
        this.UpdateRoad();
    }

    protected virtual void UpdateRoad()
    {
        distance = Vector2.Distance(CarPlayerCtrl.intance.transform.position, this.roadCurrent.transform.position);
        if (distance >= 8f)
        {
            roadSpawnPos.transform.position = new Vector2(roadCurrent.transform.position.x, roadCurrent.transform.position.y + 15f);
            this.Spawn(roadSpawnPos.transform.position);
        }
    }

    protected virtual void Spawn(Vector3 position)
    {
        this.roadCurrent = Instantiate(roadPrefab, position, roadPrefab.transform.rotation);
        this.roadCurrent.transform.parent = transform;
    }
}
