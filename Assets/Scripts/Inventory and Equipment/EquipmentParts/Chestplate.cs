using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chestplate", menuName = "Scriptable Object/Equipment/Chestplate", order = 3)]
public class Bodyarmor : Equipment
{
    public override void Equip(Equipment newItem)
    {
        int equipmentSlot = 2;

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
