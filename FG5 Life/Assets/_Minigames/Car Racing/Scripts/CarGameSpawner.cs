using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGameSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> objs;
    [SerializeField] protected GameObject objPrefab;
    [SerializeField] protected GameObject objSpawnPos;
    // time spawn
    protected float spawnTimer = 0f;
    [SerializeField] protected float spawnDelay = 2f;

    [SerializeField] private int maxNumberObj = 1;

    public List<GameObject> Objs { get => objs; set => objs = value; }
    public int MaxNumberObj { get => maxNumberObj; set => maxNumberObj = value; }

    private void Awake()
    {
        this.Objs = new List<GameObject>();
    }

    protected virtual void Update()
    {
        if (!CarGameManager.intance.IsGameRunning || CarGameManager.intance.IsGameOver) return;
        this.Spawn();
        this.CheckDead();
    }

    protected virtual void Spawn()
    {
        /*if (PlayerCtrl.intance.damageReceiver.IsDead()) return;
        if (this.objs.Count >= this.maxNumberObj) return;

        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0;*/
        if (!this.CheckSpawn()) return;

        GameObject obj = Instantiate(this.objPrefab);
        obj.transform.position = this.objSpawnPos.transform.position;
        obj.transform.parent = transform;
        obj.SetActive(true);
        this.Objs.Add(obj);
    }

    protected bool CheckSpawn()
    {
        if (CarPlayerCtrl.intance.damageReceiver.IsDead()) return false;
        if (this.Objs.Count >= this.MaxNumberObj) return false;

        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return false;
        this.spawnTimer = 0;
        return true;
    }

    protected virtual void CheckDead()
    {
        GameObject deadObj;
        for (int i = 0; i < this.Objs.Count; i++)
        {
            deadObj = this.Objs[i];
            if (deadObj == null)
            {
                this.Objs.RemoveAt(i);
            }
        }
    }
}
