using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] private float timeDestroy;
    void Start()
    {
        Invoke("Destroy", timeDestroy);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

}
