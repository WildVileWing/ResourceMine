using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationMenuManager : MonoBehaviour
{
    public Item TemporaryItem;

    #region Singleton
    public static InformationMenuManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void EquipItem() 
    {
        if(TemporaryItem != null)
        {
            TemporaryItem.Use();
            Debug.Log("Equiping from" + this.GetType());
        }
        else
        {
            Debug.Log("Item is null");
        }
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
