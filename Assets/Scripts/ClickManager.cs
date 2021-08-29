using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public double ClickAmount = 1;
    public double ClickPerClick;

    public static ClickManager Instanse;
    private void Awake()
    {
        Instanse = this;
    }

    private void OnMouseDown()
    {
        int randomNumber = UnityEngine.Random.Range(0, 101);
        if(randomNumber < StatusManager.Instance.playerStatus.CriticalChance)
        {
            ClickPerClick = ClickAmount + ClickAmount * (StatusManager.Instance.playerStatus.CriticalMultiplier * 0.01);
        }
        else
        {
            ClickPerClick = ClickAmount;
        }

        ClickPerClick = Math.Round(ClickPerClick);
        DataManager.Instance.Clicks += (ulong)ClickPerClick;


        GameManager.Instanse.RandomDropChance(10, 1);
        TextManager.Instance.UpdateInformation(DataManager.Instance.Clicks);
    }

}
