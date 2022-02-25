using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public ulong Clicks = 1000;
    public string PlayerName;
    public int Level; 
    public int MaxHealth;
    public int MaxMana;
    public int Health;
    public int Mana;
    public int BaseStrength;
    public int BaseDefense;
    public int BaseDexterity;
    public int BaseLuck;
    public int BaseCriticalChance;
    public int BaseCriticalMultiplier;
    public int Strength;
    public int Defense;
    public int Dexterity;
    public int Luck;
    public int ClickAmount = 1;
    public int CriticalChance;
    public int CriticalMultiplier;
    public int ResourceChance = 0;
    public int ResourceAmount = 0;
    public int ResourceTier = 1;
    public ulong ClickPrice;
    public ulong CriticalMultiplierPrice;
    public ulong CriticalChancePrice;
    public ulong ResourceChancePrice;
    public ulong ResourcePrice;
    public ulong ResourceTierPrice;
    public int[,] ResourceArray = new int [4,4];
    private string DataPath;

    private void DataSave()
    {
        Data data = new Data(Clicks, PlayerName, Level, MaxHealth, MaxMana, Health, Mana, BaseStrength, BaseDefense,
            BaseDexterity, BaseLuck, BaseCriticalChance, BaseCriticalMultiplier, Strength, Defense, Dexterity, Luck,
            CriticalChance, CriticalMultiplier, ResourceChance, ResourceAmount, ResourceTier, ClickAmount, ClickPrice, CriticalMultiplierPrice,
            CriticalChancePrice, ResourceChancePrice, ResourcePrice, ResourceTierPrice, ResourceArray);
        File.WriteAllText(DataPath, JsonUtility.ToJson(data));
    }
    
    private void DataLoad()
    {
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(DataPath));
        Clicks = data.clicks;
        PlayerName = data.playerName;
        Level = data.level;
        MaxHealth = data.maxHealth;
        MaxMana = data.maxMana;
        Health = data.health;
        Mana = data.mana;
        BaseStrength = data.baseStrength;
        BaseDefense = data.baseDefense;
        BaseDexterity = data.baseDexterity;
        BaseLuck = data.baseLuck;
        BaseCriticalChance = data.baseCriticalChance;
        BaseCriticalMultiplier = data.baseCriticalMultiplier;
        Strength = data.strength;
        Defense = data.defense;
        Dexterity = data.dexterity;
        Luck = data.luck;
        ClickAmount = data.clickAmount < 1 ? 1 : data.clickAmount;

        CriticalChance = data.criticalChance;
        CriticalMultiplier = data.criticalMultiplier;
        ResourceChance = data.resourceChance;
        ResourceAmount = data.resourceAmount;

        ResourceTier = data.resourceTier < 1 ? 1 : data.resourceTier;

        ClickPrice = data.clickPrice;
        CriticalMultiplierPrice = data.criticalMultiplierPrice;
        CriticalChancePrice = data.criticalChancePrice;
        ResourceChancePrice = data.resourceChancePrice;
        ResourcePrice = data.resourcePrice;
        ResourceTierPrice = data.resourceTierPrice;

        Debug.Log(ResourceArray);
        ResourceArray = data.resourceArray == null ? ResourceArray : data.resourceArray;
        Debug.Log(data.resourceArray);


    }

    private void OnApplicationFocus(bool focus)
    {
        DataSave();     
    }

    private void OnApplicationQuit()
    {
        DataSave();  
    }

    private void Awake()
    {
        Instance = this;
        DataPath = Application.persistentDataPath + "/Data.json";
        //ResourceArray = new int[4, 4];
        DataLoad();
    }

    [System.Serializable]
    public class Data 
    {
        public ulong clicks;
        public string playerName;
        public int level;
        public int maxHealth;
        public int maxMana;
        public int health;
        public int mana;
        public int baseStrength;
        public int baseDefense;
        public int baseDexterity;
        public int baseLuck;
        public int baseCriticalChance;
        public int baseCriticalMultiplier;
        public int strength;
        public int defense;
        public int dexterity;
        public int luck;
        public int clickAmount;
        public int criticalChance;
        public int criticalMultiplier;
        public int resourceChance;
        public int resourceAmount;
        public int resourceTier;
        public ulong clickPrice;
        public ulong criticalMultiplierPrice;
        public ulong criticalChancePrice;
        public ulong resourceChancePrice;
        public ulong resourcePrice;
        public ulong resourceTierPrice;
        public int[,] resourceArray = new int [4,4];

        public Data(ulong _clicks, string _playerName, int _level, int _maxHealth, int _maxMana, int _health, int _mana, int _baseStrength, int _baseDefense,
            int _baseDexterity, int _baseLuck, int _baseCriticalChance, int _baseCriticalMultiplier, int _strength, int _defense, int _dexterity, int _luck,
            int _criticalChance, int _criticalMultiplier, int _resourceChance, int _resourceAmount, int _resourceTier,
            int _clickAmount, ulong _clickPrice, ulong _criticalMultiplierPrice, ulong _criticalChancePrice, ulong _resourceChancePrice,
            ulong _resourcePrice, ulong _resourceTierPrice, int [,] _resourceArray)
        {
            clicks = _clicks;
            playerName = _playerName;
            level = _level;
            maxHealth = _maxHealth;
            maxMana = _maxMana;
            health = _health;
            mana = _mana;
            baseStrength = _baseStrength;
            baseDefense = _baseDefense;
            baseDexterity = _baseDexterity;
            baseLuck = _baseLuck;
            baseCriticalChance = _baseCriticalChance;
            baseCriticalMultiplier = _baseCriticalMultiplier;
            strength = _strength;
            defense = _defense;
            dexterity = _dexterity;
            luck = _luck;
            clickAmount = _clickAmount;
            criticalChance = _criticalChance;
            criticalMultiplier = _criticalMultiplier;
            resourceChance = _resourceChance;
            resourceAmount = _resourceAmount;
            resourceTier = _resourceTier;
            clickPrice = _clickPrice;
            criticalMultiplierPrice = _criticalMultiplierPrice;
            criticalChancePrice = _criticalChancePrice;
            resourceChancePrice = _resourceChancePrice;
            resourcePrice = _resourcePrice;
            resourceTierPrice = _resourceTierPrice;
            resourceArray = _resourceArray;
        }
    }
}
