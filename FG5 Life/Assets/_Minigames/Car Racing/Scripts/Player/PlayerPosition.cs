using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    
    List<GameObject> minions;

    public GameObject minionPrefab;

    float spawnTimer = 0f;
    float delayTimer = 1f;
    void Start()
    {
        minions = new List<GameObject>();
    }


    void Update()
    {
        Spawn();
        CheckMinionDead();
    }

    void Spawn()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer < delayTimer) return;
        spawnTimer = 0f;
        
        if (minions.Count >= 7)
        {
            return;
        }

        int index = minions.Count + 1;
        GameObject minion = Instantiate(minionPrefab);
        minion.name = "MinionPrefab " + index;

        minion.transform.position = transform.position;
        minion.gameObject.SetActive(true);

        //GameObject minion = new GameObject("Minion " + index);
        minions.Add(minion);
    }

    void CheckMinionDead()
    {
        for(int i=0; i<minions.Count; i++)
        {
            if(minions[i] == null)
            {
                minions.RemoveAt(i);
            }
        }
    }
}
