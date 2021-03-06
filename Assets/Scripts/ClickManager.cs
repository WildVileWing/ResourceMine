using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public double ClickPerClick;

    public static ClickManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void OnMouseDown()
    {
        int randomNumber = UnityEngine.Random.Range(0, 101); 
        if(randomNumber < DataManager.Instance.CriticalChance)
        {
            ClickPerClick = DataManager.Instance.ClickAmount + DataManager.Instance.ClickAmount * 
                (DataManager.Instance.CriticalMultiplier * 0.01);
        }
        else
        {
            ClickPerClick = DataManager.Instance.ClickAmount;
        }
        ClickPerClick = Math.Round(ClickPerClick);
        DataManager.Instance.Clicks += (ulong)ClickPerClick;
        TextManager.Instance.UpdateInformation(DataManager.Instance.Clicks);

        GameManager.Instanse.RandomDropChance(DataManager.Instance.ResourceTier, DataManager.Instance.ResourceChance, DataManager.Instance.ResourceAmount);
        
    }

}
