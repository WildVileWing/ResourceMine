using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instanse;
    public int RandomNumber;
    public void RandomDropChance(int chance, ulong amount)
    {   
        int RandomResource = UnityEngine.Random.Range(0, 101);
        if (RandomResource < chance) 
        {
            int RandomResourceItem = UnityEngine.Random.Range(0, 10);
            DataManager.Instance.ResourceArray[RandomResourceItem] += amount;
        }
    }
    
    private void Awake()
    {
        Instanse = this;
       
    }   
}
