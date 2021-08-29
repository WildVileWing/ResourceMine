using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipment,
    Ingredient
}

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
    public ItemType Type;
    public ItemRarity Rarity;
    public virtual void Use()
    {

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