using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float screenHalfHeightInWorldUnits;

    private float timer = 0f;
    public Vector2 secondsBetweenSpawnMinMax;

    private float spawnAngleMax = 15f;

    private void Start()
    {
        this.screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
        float obstacleHeight = obstaclePrefab.transform.localScale.y;
        this.screenHalfHeightInWorldUnits += obstacleHeight;
    }

    private void Update()
    {
        if (!GameController.Instance.IsGameRunning) return;
        float secondsBetweenSpawn = Mathf.Lerp(secondsBetweenSpawnMinMax.y, secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());
        timer += Time.deltaTime; 
        if (timer < secondsBetweenSpawn) return;
        timer = 0f;
        this.Spawn();
    }

    protected virtual void Spawn()
    {
        GameObject obstacle = Instantiate(obstaclePrefab);
        obstacle.transform.position = new Vector2(0f, this.screenHalfHeightInWorldUnits);
        float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
        obstacle.transform.Rotate(Vector3.forward * spawnAngle);
    }
}
