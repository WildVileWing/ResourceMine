using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Ingredient,
    Part
}

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Object/Ingredient")]
public class Ingredient : Item
{
    public int Price;
}
