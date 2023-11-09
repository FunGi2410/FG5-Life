using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropEvent : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On Dropppppppp");
        if (eventData.pointerDrag != null)
        {
            for(int i = 0; i < Inventory.Instance.WaveFoods.Count; i++)
            {
                string name = Inventory.Instance.WaveFoods[i].FoodPrefabs.name + "(Clone)";

                if (name == eventData.pointerDrag.name)
                {
                    if (Inventory.Instance.WaveFoods[i].Amount <= 0) return;
                    Inventory.Instance.WaveFoods[i].Amount--;
                    Inventory.Instance.SO_Inventory.WaveFoods[i].Amount = Inventory.Instance.WaveFoods[i].Amount;
                    eventData.pointerDrag.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Inventory.Instance.WaveFoods[i].Amount.ToString();

                    break;
                }
            }
        }
        Player.Instance.Eatting();
    }
}
