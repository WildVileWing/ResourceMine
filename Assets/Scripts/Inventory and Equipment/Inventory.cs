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
    
    public int InventorySlots = 28;

    public void AddItem(Item item)
    {
        if (items.Count >= InventorySlots)
        {
            Debug.Log("Not enough space");
            return;
        }
        items.Add(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
       
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        if(onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }



}
