using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    public Text ClicksText;
    public Text[] ResourceMenuArray = new Text[10];
    public GameObject CraftingMenu;
    public GameObject CaseMenu;
    public GameObject ShopMenu;
    public GameObject ResourceMenu;
    public GameObject ResourceMenuButton;

    public static TextManager Instance; 
    private void Awake()
    {
        Instance = this;
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
            ResourceMenuArray[i].text = $"{DataManager.Instance.ResourceArray[i]}";
        }
    }   
    public void OpenCraftingMenu()
    {
        CraftingMenu.SetActive(!CraftingMenu.activeSelf);
    }
    public void OpenResourcesMenu()
    {
        ResourceMenu.SetActive(!ResourceMenu.activeSelf);
    }
    public void OpenShopMenu()
    {
        ShopMenu.SetActive(!ShopMenu.activeSelf);
    }
    public void OpenCaseMenu()
    {
        CaseMenu.SetActive(!CaseMenu.activeSelf);
    }
    private void Start()
    {
        UpdateInformation(DataManager.Instance.Clicks);
    }
}
