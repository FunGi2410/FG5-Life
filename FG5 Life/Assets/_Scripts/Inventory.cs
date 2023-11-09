using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // singleton
    public static Inventory Instance { get; private set; }
    void Awake()
    {
        Instance = this;
        this.waveFoods = SO_Inventory.WaveFoods;
        this.budget = SO_Inventory.Budget;
    }

    [SerializeField] private List<Food> waveFoods;

    [SerializeField] private SO_Inventory sO_Inventory;

    [SerializeField] private int budget;

    public List<Food> WaveFoods { get => waveFoods; set => waveFoods = value; }
    public SO_Inventory SO_Inventory { get => sO_Inventory; set => sO_Inventory = value; }
    public int Budget { 
        get => budget;
        set
        {
            if (value <= 0) budget = 0;
            else budget = value;
        }
    }
}
