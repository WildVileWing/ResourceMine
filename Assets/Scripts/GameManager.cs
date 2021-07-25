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
            Debug.Log("Random.Range(0, 10) " + Math.Round(UnityEngine.Random.Range(0f, 1f), 3));
            DataManager.Instance.ResourceArray[RandomResourceItem] += amount;
        }
    }
    
    private void Awake()
    {
        Instanse = this;
       
    }   
}
