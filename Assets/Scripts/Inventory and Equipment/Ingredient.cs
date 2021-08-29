using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Object/Ingredient")]
public class Ingredient : ScriptableObject
{

    public int Count;

    [Tooltip("F  \nE  \nD  \nC  \nB  \nA  \nS  \nSS  \nSSS  \nUT  \nAR  \nAT  \nMH  \n???  \nT")]
    public string Rarity;

    public int Price;


}
