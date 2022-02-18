using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public PlayerStatus playerStatus;


    #region Singleton
    public static StatusManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        EquipmentManager.Instanse.onEquipmentChanged += UpdateCharacterStatus;
    }

    public void UpdateCharacterStatus(Equipment newItem, Equipment oldItem)
    {
        if(oldItem != null)
        {
            DataManager.Instance.Strength -= oldItem.StrengthModifier;
            DataManager.Instance.Defense -= oldItem.DefenseModifier;
            DataManager.Instance.Dexterity -= oldItem.DexterityModifier;
            DataManager.Instance.Luck -= oldItem.LuckModifier;
            DataManager.Instance.CriticalChance -= oldItem.CriticalChance;
            DataManager.Instance.CriticalMultiplier -= oldItem.CriticalMultiplier;
        }
        if(newItem != null)
        {
            DataManager.Instance.Strength += DataManager.Instance.BaseStrength + newItem.StrengthModifier;
            DataManager.Instance.Defense += DataManager.Instance.BaseDefense + newItem.DefenseModifier;
            DataManager.Instance.Dexterity += DataManager.Instance.BaseDexterity + newItem.DexterityModifier;
            DataManager.Instance.Luck += DataManager.Instance.BaseLuck + newItem.LuckModifier;
            DataManager.Instance.CriticalChance += DataManager.Instance.BaseCriticalChance + newItem.CriticalChance;
            DataManager.Instance.CriticalMultiplier += DataManager.Instance.BaseCriticalMultiplier + newItem.CriticalMultiplier;
        }
    }
}
