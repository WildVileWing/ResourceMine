using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager Instanse;

    private void Awake()
    {
        Instanse = this;
    }

    #endregion

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public Equipment[] CurrentEquipment;
    public delegate void OnEquipmentChangedCallBack1();
    public OnEquipmentChangedCallBack1 onEquiplmentChangedCallBack1;
        
    private void Start()
    {
        int numberOfSlots = 10;
        CurrentEquipment = new Equipment[numberOfSlots];
    }


    public void Unequip(int slotIndex)
    {
        if(CurrentEquipment[slotIndex] != null)
        {
            Equipment oldItem = CurrentEquipment[slotIndex];
            Inventory.Instance.AddItem(oldItem);

            CurrentEquipment[slotIndex] = null;
        }
        TextManager.Instance.UpdatePlayerStatusMenu();

        /*
        if (onEquiplmentChangedCallBack1 != null)
        {
            onEquiplmentChangedCallBack1.Invoke();
        }
        */
    }
    
}
