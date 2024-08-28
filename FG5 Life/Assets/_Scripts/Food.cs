using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Food
{
    [SerializeField] private int numberOfFull;
    [SerializeField] private int price;
    [SerializeField] private int amount;
    [SerializeField] private GameObject foodPrefabs;

    public int NumberOfFull { get => numberOfFull; set => numberOfFull = value; }
    public int Price { get => price; set => price = value; }
    public int Amount { 
        get => amount; 
        set
        {
            if (value <= 0) amount = 0;
            else amount = value;
        }
    }
    public GameObject FoodPrefabs { get => foodPrefabs; set => foodPrefabs = value; }
}



