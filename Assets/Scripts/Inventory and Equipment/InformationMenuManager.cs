using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationMenuManager : MonoBehaviour
{
    public void EquipItem()
    {
        Debug.Log("InformationMenu " + InventorySlot.Instanse.item);

    }
    public void OpenInformationMenu()
    {
        Debug.Log("OpenInformationMenu " + InventorySlot.Instanse.item);
        InventorySlot.Instanse.InformationArray = InventorySlot.Instanse.item.GetInformation();
        for (int i = 0; i < InventorySlot.Instanse.InformationArray.Length; i++)
        {
            InventorySlot.Instanse.InformationTextArray[i].text = $"{InventorySlot.Instanse.InformationArray[i]}";
        }
        TextManager.Instance.InformationMenu.SetActive(true);
    }

    public void CloseInformationMenu()
    {
        TextManager.Instance.InformationMenu.SetActive(false);
    }

}
