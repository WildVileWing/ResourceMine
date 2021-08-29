using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerStatusData", menuName = "Scriptable Object/PlayerStatusData")]
public class PlayerStatus : ScriptableObject
{
    public string PlayerName;
    public int Level;
    public int MaxHealth;
    public int MaxMana;
    public int Health;
    public int Mana;
    public int BaseStrength;
    public int BaseDefense;
    public int BaseDexterity;
    public int BaseCriticalChance;
    public int BaseCriticalMultiplier;
    public int BaseLuck;
    public int Strength;
    public int Defense;
    public int Dexterity;
    public int Luck;


    public int CriticalChance;
    public int CriticalMultiplier;

}
