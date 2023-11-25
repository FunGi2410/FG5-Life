using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : CarGameSpawner
{
    [SerializeField] private List<GameObject> enemies;

    public List<GameObject> Enemies { get => enemies; set => enemies = value; }

    private float ranPosX;
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
        int indexEnemy = Random.Range(0, this.Enemies.Count);
        GameObject obj = Instantiate(this.Enemies[indexEnemy]);
        // random pos
        this.ranPosX = Random.Range(-sizeOfRoad.x, sizeOfRoad.x);
        obj.transform.parent = transform;
        obj.transform.position = this.objSpawnPos.transform.position;
        obj.transform.position = new Vector2(this.ranPosX, this.objSpawnPos.transform.position.y);
        
        this.Objs.Add(obj);
    }

    protected override void Update()
    {
        if (!CarGameManager.intance.IsGameRunning || CarGameManager.intance.IsGameOver) return;
        this.Spawn();
        this.CheckDead();
    }
}
