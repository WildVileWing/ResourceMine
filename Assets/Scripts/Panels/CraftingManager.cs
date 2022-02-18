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

    public void CraftItem(Item result, params Item[] craftingMaterials)
    {
        if (!Inventory.Instance.IsInventoryFull())
        {
            for(int i = 0; i < craftingMaterials.Length; i++)
            {
                Inventory.Instance.RemoveItem(Inventory.Instance.ItemSearch(craftingMaterials[i]));
                Debug.Log("Item: " + craftingMaterials[i].Name + ", Amount = " + craftingMaterials[i].StackAmount);
            }
        }
        else
        {
            Debug.Log("Inventory is full, delete some items");
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
