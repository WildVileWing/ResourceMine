using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Helmet", menuName = "Scriptable Object/Equipment/Helmet", order = 1)]
public class Helmet : Equipment
{
    public override void Equip(Equipment newItem)
    {
        int equipmentSlot = 0;

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
