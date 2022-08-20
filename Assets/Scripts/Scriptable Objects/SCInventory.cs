using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable/Inventory")]
public class SCInventory : ScriptableObject
{
    public List<Slot> InventorySlots = new List<Slot>();
    int stackLimit = 4;
    public void AddItem(SCItem item)
    {
       
        foreach (Slot slot in InventorySlots)
        {
            if (slot.item == item)
            {
                if (slot.item.canStackable)
                {
                   
                  
                    if (slot.itemCount < stackLimit/* && slot.item.itemName==item.itemName*/)
                    {   
                        slot.itemCount++;
                        if (slot.itemCount >= (stackLimit ))
                        {
                            slot.isFull = true;
                        }
                        break; 
                    }
                    
                }

            }
            else if(slot.itemCount==0)
            {
                slot.AddItemToSlot(item);
                break;
            }
        }
    }
}
[System.Serializable]
public class Slot
{
    public bool isFull;
    public int itemCount;
    public SCItem item;
    public void AddItemToSlot(SCItem item)
    {
       
        this.item = item;
        if (!item.canStackable)
        {
            isFull = true;

        }
        itemCount++;
    }
}
