using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : CarGameSpawner
{
    [SerializeField] private List<GameObject> obstacles;

    public List<GameObject> Obstacles { get => obstacles; set => obstacles = value; }

    private float ranPosX;
    private float ranPosY;
    private int disSpawnPosY = 5;
    [SerializeField] private Transform roadTrans;
    [SerializeField] private Vector3 sizeOfRoad;

    private void Start()
    {
        this.sizeOfRoad = this.roadTrans.GetChild(0).GetComponent<SpriteRenderer>().bounds.size;
        this.sizeOfRoad /= 2;
    }

    protected override void Spawn()
    {
        if (!this.CheckSpawn()) return;

        this.InitRandomObject();
    }

    private void InitRandomObject()
    {
        // spawn random obj in enemies list
        int indexEnemy = Random.Range(0, this.obstacles.Count);
        GameObject obj = Instantiate(this.obstacles[indexEnemy]);
        // random pos
        this.ranPosX = Random.Range(-sizeOfRoad.x, sizeOfRoad.x);
        this.ranPosY = Random.Range(this.objSpawnPos.transform.position.y, this.objSpawnPos.transform.position.y + this.disSpawnPosY);

        obj.transform.parent = transform;
        obj.transform.position = this.objSpawnPos.transform.position;
        obj.transform.position = new Vector2(this.ranPosX, this.ranPosY);

        this.Objs.Add(obj);
    }

    protected override void Update()
    {
        if (!CarGameManager.intance.IsGameRunning || CarGameManager.intance.IsGameOver) return;
        this.Spawn();
        this.CheckDead();
    }
}
