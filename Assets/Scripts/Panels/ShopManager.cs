using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject DescriptionObject;
    public Text DescriptionText;
    public RectTransform DescriptionWindow;
    public RectTransform Bounds;
    public GameObject ShopPanel;
    public BoxCollider2D ClickPanelCollider;
    public ulong BaseClickPrice;
    public ulong BaseCriticalMultiplierPrice;
    public ulong BaseCriticalChancePrice;
    public ulong BaseResourceChancePrice;
    public ulong BaseResourceAmountPrice;
    public ulong BaseResourceTierPrice;

    public ulong ClickPrice;
    public ulong CriticalMultiplierPrice;
    public ulong CriticalChancePrice;
    public ulong ResourceChancePrice;
    public ulong ResourceAmountPrice;
    public ulong ResourceTierPrice;
    public string[] ListOfDescription = new string[6];
    public Text[] ListOfButtonsPriceText = new Text[6];
    public ulong[] ListOfPrices = new ulong[6];


    #region Singleton

    private void Awake()
    {
        
        ListOfButtonsPriceText[0].text = DataManager.Instance.ClickPrice + "$";
        ListOfButtonsPriceText[1].text = DataManager.Instance.CriticalMultiplierPrice + "$";
        ListOfButtonsPriceText[2].text = DataManager.Instance.CriticalChancePrice + "$";
        ListOfButtonsPriceText[3].text = DataManager.Instance.ResourceChancePrice + "$";
        ListOfButtonsPriceText[4].text = DataManager.Instance.ResourcePrice + "$";
        ListOfButtonsPriceText[5].text = DataManager.Instance.ResourceTierPrice + "$";
    }
    #endregion

    public void ShowDescriptionOnTouch(int id)
    { 
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(240,-500,0));
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;
        DescriptionObject.transform.position = mouseWorldPosition;
        DescriptionText.text = ListOfDescription[id];
        DescriptionObject.SetActive(!DescriptionObject.activeSelf);     
    }

    public void BuyClicks()
    {
        if(DataManager.Instance.Clicks > DataManager.Instance.ClickPrice)
        {
            DataManager.Instance.Clicks -= DataManager.Instance.ClickPrice;
            DataManager.Instance.ClickPrice = (ulong)Mathf.Ceil(DataManager.Instance.ClickPrice * 1.4f);
            DataManager.Instance.ClickAmount += 1;
           
            TextManager.Instance.UpdateInformation(DataManager.Instance.Clicks);
            ListOfButtonsPriceText[0].text = DataManager.Instance.ClickPrice + "$";
        }
    }

    public void BuyCriticalMultiplier()
    {
        if (DataManager.Instance.Clicks > DataManager.Instance.CriticalMultiplierPrice)
        {
            DataManager.Instance.Clicks -= DataManager.Instance.CriticalMultiplierPrice;
            DataManager.Instance.CriticalMultiplierPrice = (ulong)Mathf.Ceil(DataManager.Instance.CriticalMultiplierPrice * 1.8f);
            DataManager.Instance.CriticalMultiplier += 1;
            TextManager.Instance.UpdateInformation(DataManager.Instance.Clicks);
            ListOfButtonsPriceText[1].text = DataManager.Instance.CriticalMultiplierPrice + "$";
        }
    }

    public void BuyCriticalChance()
    {
        if (DataManager.Instance.Clicks > DataManager.Instance.CriticalChancePrice)
        {
            DataManager.Instance.Clicks -= DataManager.Instance.CriticalChancePrice;
            DataManager.Instance.CriticalChancePrice = (ulong)Mathf.Ceil(DataManager.Instance.CriticalChancePrice * 1.5f);
            DataManager.Instance.CriticalChance += 1;
            TextManager.Instance.UpdateInformation(DataManager.Instance.Clicks);
            ListOfButtonsPriceText[2].text = DataManager.Instance.CriticalChancePrice + "$";
        }
    }
    public void BuyResourceChance()
    {
        if (DataManager.Instance.Clicks > DataManager.Instance.ResourceChancePrice)
        {
            DataManager.Instance.Clicks -= DataManager.Instance.ResourceChancePrice;
            DataManager.Instance.ResourceChancePrice = (ulong)(DataManager.Instance.ResourceChancePrice * 2);
            DataManager.Instance.ResourceChance += 1;
            TextManager.Instance.UpdateInformation(DataManager.Instance.Clicks);
            ListOfButtonsPriceText[3].text = DataManager.Instance.ResourceChancePrice + "$";
        }
    }

    public void BuyResourceAmount()
    {
        if (DataManager.Instance.Clicks > DataManager.Instance.ResourcePrice)
        {
            DataManager.Instance.Clicks -= ResourceAmountPrice;
            DataManager.Instance.ResourcePrice = (ulong)Mathf.Ceil(DataManager.Instance.ResourcePrice * 2.5f);
            DataManager.Instance.ResourceAmount += 1;
            TextManager.Instance.UpdateInformation(DataManager.Instance.Clicks);
            ListOfButtonsPriceText[4].text = DataManager.Instance.ResourcePrice + "$";
        }
    }

    public void BuyResourceTier()
    {
        if (DataManager.Instance.Clicks > DataManager.Instance.ResourceTierPrice)
        {
            DataManager.Instance.Clicks -= DataManager.Instance.ResourceTierPrice;
            DataManager.Instance.ResourceTierPrice = (ulong)(DataManager.Instance.ResourceTierPrice * 10);
            DataManager.Instance.ResourceAmount += 1;
            TextManager.Instance.UpdateInformation(DataManager.Instance.Clicks);
            ListOfButtonsPriceText[5].text = DataManager.Instance.ResourceTierPrice + "$";
        }
    }

    public void UpdateDescription(int id, string Description)
    {
        ListOfDescription[id] = Description;
    }

    public void CloseDescription()
    {
        DescriptionObject.SetActive(false);
    }

    public void CheckOffPanel()
    {
        Vector3 descriptionObject = DescriptionObject.transform.position;
        Debug.Log(descriptionObject); 
        Debug.Log(ClickPanelCollider.bounds.Contains(descriptionObject));
        if(ClickPanelCollider.bounds.Contains(descriptionObject))
        {
            DescriptionText.color = Color.green;
        }
        else
        {
            DescriptionText.color = Color.red;
        }
        ShowDescriptionOnTouch(5);
    }
}
