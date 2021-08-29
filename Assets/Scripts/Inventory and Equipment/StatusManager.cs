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
            playerStatus.Strength           -= oldItem.StrengthModifier;
            playerStatus.Defense            -= oldItem.DefenseModifier;
            playerStatus.Dexterity          -= oldItem.DexterityModifier;
            playerStatus.Luck               -= oldItem.LuckModifier;
            playerStatus.CriticalChance     -= oldItem.CriticalChance;
            playerStatus.CriticalMultiplier -= oldItem.CriticalMultiplier;
        }
        playerStatus.Strength            = playerStatus.BaseStrength           + playerStatus.Strength           + newItem.StrengthModifier;
        playerStatus.Defense             = playerStatus.BaseDefense            + playerStatus.Defense            + newItem.DefenseModifier;
        playerStatus.Dexterity           = playerStatus.BaseDexterity          + playerStatus.Dexterity          + newItem.DexterityModifier;
        playerStatus.Luck                = playerStatus.BaseLuck               + playerStatus.Luck               + newItem.LuckModifier;
        playerStatus.CriticalChance      = playerStatus.BaseCriticalChance     + playerStatus.CriticalChance     + newItem.CriticalChance;
        playerStatus.CriticalMultiplier  = playerStatus.BaseCriticalMultiplier + playerStatus.CriticalMultiplier + newItem.CriticalMultiplier;
    }
}
