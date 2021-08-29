using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boots", menuName = "Scriptable Object/Equipment/Boots", order = 7)]
public class Boots : Equipment
{
    public override void Equip(Equipment newItem)
    {
        int equipmentSlot = 9;

        Equipment previousItem = null;

        if (EquipmentManager.Instanse.CurrentEquipment[equipmentSlot] != null)
        {
            previousItem = EquipmentManager.Instanse.CurrentEquipment[equipmentSlot];
            Inventory.Instance.AddItem(previousItem);
        }
        EquipmentManager.Instanse.CurrentEquipment[equipmentSlot] = newItem;

        StatusManager.Instance.UpdateCharacterStatus(newItem, previousItem);
        if (onEquiplmentChangedCallBack != null)
        {
            onEquiplmentChangedCallBack.Invoke();
        }
    }
    
}
