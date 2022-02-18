using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Amulet,
    Body,
    LeftHand,
    RightHand,
    Belt,
    LeftRing,
    RightRing,
    Legs,
    Boots,
}

public enum Attribute
{
    Armor,
    Damage,
    Poison
}
public enum Abilities
{
    Null,
    Greed,
    BloodyChoice,
}

public enum PassiveAbilities
{
    Null,
    CriticalChance,
    CriticalMultiplier,
    ResourceAmount
}


public class Equipment : Item
{
    [HideInInspector]
    private new const int StackAmount = 1;
    public EquipmentType equipmentType;

    public int StrengthModifier;
    public int DefenseModifier;
    public int DexterityModifier;
    public int LuckModifier;

    public int CriticalChance;
    public int CriticalMultiplier;

    public Attribute mainAttribute;
    public int mainAttributeAmount;

    public Abilities Ability;
    public string AbilityDescription;

    public PassiveAbilities Passive;
    public string PassiveDescription;

    public delegate void OnEquipmentChangedCallBack();
    public OnEquipmentChangedCallBack onEquiplmentChangedCallBack;


    public void GetDescription()
    {
        switch (this.Passive)
        {
            case PassiveAbilities.CriticalChance:
                this.PassiveDescription = "Critical Chance + 10%";
                break;
            case PassiveAbilities.CriticalMultiplier:
                this.PassiveDescription = "Critical Multiplier + 50%";
                break;
            case PassiveAbilities.ResourceAmount:
                this.PassiveDescription = "Resource Amount + 100%";
                break;
        
            default:
                this.PassiveDescription = null;
                break;
        }
        switch (this.Ability)
        {
            case Abilities.Greed:
                this.AbilityDescription = "Any click have 1% to get 2x gold for 3 seconds";
                break;
            case Abilities.BloodyChoice:
                this.AbilityDescription = "";
                break;
        }

    }
    public override string[] GetInformation()
    {
        int[] modifierArray = new int[4] {this.StrengthModifier, this.DefenseModifier, this.DexterityModifier, this.LuckModifier };
        string[] modifierNameArray = new string[4] { "Strength", "Defense", "Dexterity", "Luck" };
        string[] informationArray = new string[10];
        this.GetDescription();
        switch (this.Rarity)
        {
            case ItemRarity.Trash:
                informationArray[0] = $"<color=#414141>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#414141> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.F:
                informationArray[0] = $"<color=#363434>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#363434> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.E:
                informationArray[0] = $"<color=#3c3b3b>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#3c3b3b> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.D:
                informationArray[0] = $"<color=#777777>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#777777> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.C:
                informationArray[0] = $"<color=#59a719>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#59a719> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.B:
                informationArray[0] = $"<color=#1960a7>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#1960a7> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.A:
                informationArray[0] = $"<color=#d2893f>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#d2893f> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.S:
                informationArray[0] = $"<color=#c63d3c>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#c63d3c> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.Untiered:
                informationArray[0] = $"<color=#7b43de>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#7b43de> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.Legendary:
                informationArray[0] = $"<color=#e6e039>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#e6e039> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.Godly:
                informationArray[0] = $"<color=#38d0eb>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#38d0eb> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.Arcanic:
                informationArray[0] = $"<color=#db942a>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#db942a> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.Ancient:
                informationArray[0] = $"<color=#ab1b1b>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#ab1b1b> {this.Rarity.ToString()}</color>";
                break;

            case ItemRarity.Unknown:
                informationArray[0] = $"<color=#ffffff>{this.Name}</color>";
                informationArray[9] = "<color=#ffffff> Rarity: </color>" + $"<color=#ffffff> {this.Rarity.ToString()}</color>";
                break;
        }
 
        informationArray[2] = this.mainAttribute.ToString();
        informationArray[3] = $"<color=#ffffff> {this.mainAttributeAmount} </color> ";
        for (int i = 0; i < 4; i++)
        {
            if (modifierArray[i] != 0)
            {
                informationArray[4] += $"<color=#3455c9> +{modifierArray[i]} {modifierNameArray[i]} </color>\n";
            }

        }

        if (this.Ability == Abilities.Null)
        {
            if (this.Passive != PassiveAbilities.Null)
            {
                informationArray[5] = $"<color=#ffffff>{this.Passive}</color>";
                informationArray[6] = this.PassiveDescription;
            }
        }
        else
        {
            informationArray[5] = $"<color=#ffffff>{this.Ability}</color>";
            informationArray[6] = this.AbilityDescription;
            if (this.Passive != PassiveAbilities.Null)
            {
                informationArray[7] = $"<color=#ffffff>{this.Passive}</color>";
                informationArray[8] = this.PassiveDescription;
            }
        }
        return informationArray;
    }

    public virtual void Equip(Equipment newItem)
    {

    }
    public virtual void Unequip(int slotIndex)
    {     
        if (EquipmentManager.Instanse.CurrentEquipment[slotIndex] != null)
        {
            Equipment oldItem = EquipmentManager.Instanse.CurrentEquipment[slotIndex];
            Inventory.Instance.AddItem(oldItem);
            EquipmentManager.Instanse.CurrentEquipment[slotIndex] = null;
            //StatusManager.Instance.UpdateCharacterStatus(null, oldItem);
        }
    }

    public override void Use()
    {   
        base.Use();
        Equip(this);
        Inventory.Instance.RemoveItem(this);
    }

}
