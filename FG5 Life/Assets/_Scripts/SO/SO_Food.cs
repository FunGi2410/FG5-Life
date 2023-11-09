using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Food : ScriptableObject
{
    [SerializeField] private Food food;

    public Food Food { get => food; set => food = value; }
}
