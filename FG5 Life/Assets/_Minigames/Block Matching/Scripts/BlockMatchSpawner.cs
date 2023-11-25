using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMatchSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    private int randomIndexEnemy;
    private float screenHalfHeightInWorldUnits;

    private float timer = 0f;
    public Vector2 secondsBetweenSpawnMinMax;

    private float spawnAngleMax = 15f;

    private void Start()
    {
        this.screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
        float obstacleHeight = enemyPrefabs[0].transform.localScale.y;
        this.screenHalfHeightInWorldUnits += obstacleHeight;
    }

    private void Update()
    {
        //if (!GameController.Instance.IsGameRunning) return;
        if (!BlockMatchGameManager.Instance.IsGameRunning) return;
        float secondsBetweenSpawn = Mathf.Lerp(secondsBetweenSpawnMinMax.y, secondsBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());
        timer += Time.deltaTime;
        if (timer < secondsBetweenSpawn) return;
        timer = 0f;
        this.Spawn();
    }

    protected virtual void Spawn()
    {
        this.randomIndexEnemy = Random.Range(0, this.enemyPrefabs.Count);
        GameObject obstacle = Instantiate(enemyPrefabs[randomIndexEnemy]);
        obstacle.transform.position = new Vector2(0f, this.screenHalfHeightInWorldUnits);
        float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
        obstacle.transform.Rotate(Vector3.forward * spawnAngle);
    }
}
