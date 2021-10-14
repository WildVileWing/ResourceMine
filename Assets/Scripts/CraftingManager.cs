using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public Item[] CraftItems;
    public GameObject BackgroundPanel;
    public GameObject ItemRarityGlow;
    public Image ItemIcon;
    public Text ItemName;

    public void CraftItem(params Item[] items)
    {
        if(Inventory.Instance.items.Count >= Inventory.Instance.InventorySlots)
        {
            Debug.Log("Not enough space");
            return;

        }
        for (int i = 0; i < items.Length; i++)
        {
            if (true)
            {

            }
            Inventory.Instance.RemoveItem(items[i]);
            if (Inventory.Instance.ItemSearch(items[i]))
            {

            }
            else
            {

            }
        }

    }

    public void CheckCrafts()
    {
        for(int i = 0; i < CraftItems.Length; i++)
        {
            // CraftItems[i]; ;
            if (true)
            {
                //CraftItems button.Interactable;
            }
        }
    }
   
}
