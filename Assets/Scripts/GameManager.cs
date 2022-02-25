﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instanse;
    public int RandomNumber;
    public void RandomDropChance(int tier, int chance, int amount)
    {   
        int RandomResourceChance = UnityEngine.Random.Range(0, 101);
        int RandomTier = UnityEngine.Random.Range(0, tier);
        if (RandomResourceChance < chance) 
        {
            int RandomResourceItem = UnityEngine.Random.Range(0, 4);
            Debug.Log(RandomTier);
            Debug.Log(RandomResourceItem);
            Debug.Log(DataManager.Instance.ResourceArray);
            DataManager.Instance.ResourceArray[RandomTier, RandomResourceItem] += amount;
        }
    }
    
    private void Awake()
    {
        Instanse = this;
    }   
}
