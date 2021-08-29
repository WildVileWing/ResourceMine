using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Object/Equipment/Weapon", order = 4)]
public class Weapon : Equipment
{
    public override void Equip(Equipment newItem)
    {
        int equipmentSlotLeft = 3;
        int equipmentSlotRight = 4;
        Equipment previousItem = null;
        if (EquipmentManager.Instanse.CurrentEquipment[equipmentSlotLeft] != null)
        {
            if (EquipmentManager.Instanse.CurrentEquipment[equipmentSlotRight] != null)
            {
                previousItem = EquipmentManager.Instanse.CurrentEquipment[equipmentSlotRight];
                Inventory.Instance.AddItem(previousItem);
                EquipmentManager.Instanse.CurrentEquipment[equipmentSlotRight] = newItem;
            }
            else
            {
                EquipmentManager.Instanse.CurrentEquipment[equipmentSlotRight] = newItem;
            }
        }
        else
        {
            EquipmentManager.Instanse.CurrentEquipment[equipmentSlotLeft] = newItem;
        }

        StatusManager.Instance.UpdateCharacterStatus(newItem, previousItem);
        if (onEquiplmentChangedCallBack != null)
        {
            onEquiplmentChangedCallBack.Invoke();
        }
    }
}

