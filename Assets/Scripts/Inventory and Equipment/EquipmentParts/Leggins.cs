using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Leggins", menuName = "Scriptable Object/Equipment/Leggins", order = 6)]
public class Leggins : Equipment
{
    public override void Equip(Equipment newItem)
    {
        int equipmentSlot = 8;

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
