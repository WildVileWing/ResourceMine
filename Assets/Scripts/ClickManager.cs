using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    
    private void OnMouseDown()
    {
        DataManager.Instance.Clicks += 1;
        GameManager.Instanse.RandomDropChance(10, 1);
        TextManager.Instance.UpdateInformation(DataManager.Instance.Clicks);
    }

}
