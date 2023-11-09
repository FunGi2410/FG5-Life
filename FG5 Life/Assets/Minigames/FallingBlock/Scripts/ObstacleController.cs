using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Vector2 speedMinMax;
    private float speed;
    public Vector2 spawnSizeMinMax;

    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        // Random Scale
        float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
        transform.localScale = Vector2.one * spawnSize;
        // Random x position
        float halfObstacle = transform.localScale.x / 2f;
        float screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfObstacle;
        float ranPositionX = Random.Range(-screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits);
        transform.position = new Vector2(ranPositionX, transform.position.y);
    }
    private void Update()
    {
        this.Fall();
    }

    protected virtual void Fall()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
