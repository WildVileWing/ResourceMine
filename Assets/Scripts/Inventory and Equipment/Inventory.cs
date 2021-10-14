using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemAction
{
    Use,
    Equip,
    Drop
}

public class Inventory : MonoBehaviour
{
    
    #region Singleton
    public static Inventory Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public List<Item> items = new List<Item>();
    
    public int InventorySlots = 44;

    public void AddItem(Item item)
    {
        if (item.GetType().BaseType.Name == "Equipment")
        {
            if(items.Count >= InventorySlots)
            {
                Debug.Log("Not enough space");
                return;
            }
            else
            {
                items.Add(item);
            }
        }
        else
        {
            if (ItemSearch(item) != null)
            {
                item.StackAmount++;
            }
            else
            {
                items.Add(item);
            }
        }
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }

    public void RemoveItem(Item item)
    {
        if(item.StackAmount > 1)
        {
            item.StackAmount--;
        }
        else
        {
            items.Remove(item);
        }
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }

    public Item ItemSearch(Item item)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i] == item)
            {
                return item;
            }
        }
        return null;
    }
}
