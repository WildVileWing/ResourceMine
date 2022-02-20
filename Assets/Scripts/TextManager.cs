using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    // public variables
    public Text ClicksText;
    public GameObject ClickButton;
    public Text[] ResourceMenuArray = new Text[10];
    public GameObject[] menuArray;
    public GameObject CraftingMenu;
    public GameObject InventoryMenu;
    public GameObject ShopMenu;
    public GameObject ResourceMenu;
    public GameObject ResourceMenuButton;
    public GameObject InformationMenu;
    public Image[] IconEquipmentArray = new Image[10];
    public Text[] PlayerStatusArray = new Text[7];
    public GameObject RarityButton;
    public Image RarityImage;

    // private variables
    double avarageClick;

    #region Singleton
    public static TextManager Instance; 
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private void Start()
    {
        UpdateInformation(DataManager.Instance.Clicks);
        UpdatePlayerStatusMenu();
    }
    public void OpenMenu(int index)
    {
        menuArray[index].SetActive(!menuArray[index].activeSelf);
        for (int i = 0; i < menuArray.Length; i++)
        {
            if(i != index)
            {
                menuArray[i].SetActive(false);
            }
        }
        ClickButton.GetComponent<BoxCollider2D>().enabled = !menuArray[index].activeSelf;
    }

    public void UpdateInformation(ulong clicks)
    {
        ClicksText.text = $"{clicks}";
        UpdateInformationAboutResources();
    }

    public void UpdateInformationAboutResources() 
    { 
        for(int i = 0; i < ResourceMenuArray.Length; i++)
        {
            ResourceMenuArray[i].text = $"{DataManager.Instance.ResourceArray[1,i]}"; 
        }
    }
    public void UpdatePlayerStatusMenu()
    {
        avarageClick = DataManager.Instance.ClickAmount + DataManager.Instance.ClickAmount * ((DataManager.Instance.CriticalChance / 100) * StatusManager.Instance.playerStatus.CriticalMultiplier / 100);
        for(int i = 0; i < IconEquipmentArray.Length; i++)
        {
            if(EquipmentManager.Instanse.CurrentEquipment[i] != null)
            {
                IconEquipmentArray[i].sprite = EquipmentManager.Instanse.CurrentEquipment[i].Icon;
                IconEquipmentArray[i].enabled = true;
            }
            else
            {
                IconEquipmentArray[i].enabled = false;
            }
        }
        PlayerStatusArray[0].text = DataManager.Instance.Strength.ToString();
        PlayerStatusArray[1].text = DataManager.Instance.Defense.ToString();
        PlayerStatusArray[2].text = DataManager.Instance.Dexterity.ToString();
        PlayerStatusArray[3].text = DataManager.Instance.Luck.ToString();
        PlayerStatusArray[4].text = Math.Round(avarageClick, 2).ToString();
        PlayerStatusArray[5].text = $"{DataManager.Instance.CriticalChance}%";
        PlayerStatusArray[6].text = $"{DataManager.Instance.CriticalMultiplier}%";
    }
    public void OpenResourcesMenu()
    {
        OpenMenu(0);
    }
    public void OpenInventoryMenu()
    {

        OpenMenu(1);
    }
    public void OpenShopMenu()
    {
        OpenMenu(2);
    }
    public void OpenCraftingMenu()
    {
        OpenMenu(3);
    }   
    public void OpenPlayerStatusMenu()
    {
        UpdatePlayerStatusMenu();
        OpenMenu(4);
    }
}
