using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Amulet", menuName = "Scriptable Object/Equipment/Amulet", order = 2)]
public class Amulet : Equipment
{
    public override void Equip(Equipment newItem)
    {
        int equipmentSlot = 1;

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
