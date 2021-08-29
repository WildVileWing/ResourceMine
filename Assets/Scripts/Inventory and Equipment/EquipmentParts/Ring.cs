using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ring", menuName = "Scriptable Object/Equipment/Ring", order = 5)]
public class Ring : Equipment
{
    public override void Equip(Equipment newItem)
    {
        int Left = 6;
        int Right = 7;
        Equipment previousItem = null;
        if (EquipmentManager.Instanse.CurrentEquipment[Left] != null)
        {
            if (EquipmentManager.Instanse.CurrentEquipment[Right] != null)
            {
                previousItem = EquipmentManager.Instanse.CurrentEquipment[Right];
                Inventory.Instance.AddItem(previousItem);
                EquipmentManager.Instanse.CurrentEquipment[Right] = newItem;
            }
            else
            {
                EquipmentManager.Instanse.CurrentEquipment[Right] = newItem;
            }
        }
        else
        {
            EquipmentManager.Instanse.CurrentEquipment[Left] = newItem;
        }

        StatusManager.Instance.UpdateCharacterStatus(newItem, previousItem);
        if (onEquiplmentChangedCallBack != null)
        {
            onEquiplmentChangedCallBack.Invoke();
        }
    }
}
