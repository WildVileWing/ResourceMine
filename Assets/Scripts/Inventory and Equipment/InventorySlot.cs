using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;

    public Image Icon;
    public Button InformationButton;
    public string[] InformationArray = new string[10];
    public Text[] InformationTextArray = new Text[10];
    public static InventorySlot Instanse;
    private void Awake()
    {
        Instanse = this;
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        Icon.sprite = item.Icon;
        Icon.enabled = true;
        InformationButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        Icon.sprite = null;
        Icon.enabled = false;
        InformationButton.interactable = false;
    }
    public void OpenIMenu()
    {
        OpenInformationMenu(item, InformationArray, InformationTextArray);
    }

    public void OpenInformationMenu(Item item, string[] InfoArray, Text[] InfoTextArray)
    {
        Debug.Log("OpenInformationMenu " + item);
        InfoArray = item.GetInformation();
        for (int i = 0; i < InfoArray.Length; i++)
        {
            InfoTextArray[i].text = $"{InfoArray[i]}";
        }
        TextManager.Instance.InformationMenu.SetActive(true);
    }
    public void CloseInformationMenu()
    {
        TextManager.Instance.InformationMenu.SetActive(false);
    }

    public void RarityNotification()
    {
        NotificationManager.Instance.ShowRarityNotification(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            NotificationManager.Instance.ShowRarityNotification(item);
            item.Use();
        
        }
        
    }




}


