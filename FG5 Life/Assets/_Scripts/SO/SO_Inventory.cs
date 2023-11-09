using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Inventory : ScriptableObject
{
    [SerializeField] private List<Food> waveFoods;

    [SerializeField] private int budget;

    public List<Food> WaveFoods { get => waveFoods; set => waveFoods = value; }
    public int Budget { get => budget; set => budget = value; }
}
