using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public Text ItemAmountText;
    public int ItemAmount;
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
        if(item.GetType().BaseType.Name != "Equipment" )
        {
            ItemAmountText.text = item.StackAmount.ToString();
        }
        Icon.sprite = item.Icon;
        Icon.enabled = true;
        InformationButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        ItemAmountText.text = null;
        Icon.sprite = null;
        Icon.enabled = false;
        InformationButton.interactable = false;
    }
    public void OpenInformationMenu()
    {
        InformationArray = item.GetInformation();
        for (int i = 0; i < InformationArray.Length; i++)
        {
            InformationTextArray[i].text = $"{InformationArray[i]}";
        }
        TextManager.Instance.InformationMenu.SetActive(true);
        InformationMenuManager.Instance.TemporaryItem = item;
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


