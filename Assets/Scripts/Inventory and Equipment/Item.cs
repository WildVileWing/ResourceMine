using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemRarity
{
    Trash,
    F,  
    E,
    D,
    C,
    B,
    A,
    S,
    Untiered,
    Legendary,
    Godly,
    Arcanic, 
    Ancient,  
    Unknown
}


[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{

    public string Name;
    public Sprite Icon;
    public int StackAmount;
    public ItemRarity Rarity;
    public virtual void Use()
    {
        Debug.Log(StackAmount);
    }

    public virtual string[] GetInformation()
    {
        return null;
    }

    public virtual void RemoveItem()
    {
        Inventory.Instance.RemoveItem(this);
    }
}
