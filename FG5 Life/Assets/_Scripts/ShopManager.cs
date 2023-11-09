using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    private void Start()
    {
        this.shopPanel.SetActive(false);
    }

    public void BuyFood()
    {
        GameObject myButtonGameObject = EventSystem.current.currentSelectedGameObject;
        //print("Button: " + myButtonGameObject.transform.parent.name);
        string name = myButtonGameObject.transform.parent.name;


        for (int i = 0; i < Inventory.Instance.WaveFoods.Count; i++)
        {
            if (name == Inventory.Instance.WaveFoods[i].FoodPrefabs.name)
            {
                // decrease my coin
                Inventory.Instance.Budget -= Inventory.Instance.WaveFoods[i].Price;
                Inventory.Instance.SO_Inventory.Budget = Inventory.Instance.Budget;
                UIManager.Instance.SetBudgetTxt();

                // increse food amount
                Inventory.Instance.WaveFoods[i].Amount++;
                Inventory.Instance.SO_Inventory.WaveFoods[i].Amount = Inventory.Instance.WaveFoods[i].Amount;

                //update UI
                //eventData.pointerDrag.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Inventory.Instance.WaveFoods[i].Amount.ToString();

                return;
            }
        }
        Food food = myButtonGameObject.transform.parent.GetComponent<FoodData>().SO_Food.Food;
        //GameObject foodObj = Instantiate(food.SO_Food.Food.FoodPrefabs, this.transform);
        Inventory.Instance.WaveFoods.Add(food);
    }

    public void OpenShop()
    {
        this.shopPanel.SetActive(true);
    }

    public void ExitShop()
    {
        UIManager.Instance.OnLoadEatScene();
        //this.shopPanel.SetActive(false);
    }
}
