using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodOnTable : MonoBehaviour
{
    void Start()
    {
        // Load your food into table
        for (int i = 0; i < Inventory.Instance.WaveFoods.Count; i++)
        {
            GameObject foodObj = Instantiate(Inventory.Instance.WaveFoods[i].FoodPrefabs, this.transform);
            string amount = Inventory.Instance.WaveFoods[i].Amount.ToString();
            foodObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = amount; 
        }

    }
}
