using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDesSpawner : MonoBehaviour
{
    public virtual void Despawn()
    {
        Destroy(gameObject);
    }
}
