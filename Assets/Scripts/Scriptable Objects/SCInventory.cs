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
        for (int i = 0; i < InventorySlots.Count; i++)
        {

            if (InventorySlots[i].item == item)
            {
                if (InventorySlots[i].item.canStackable)
                {
                    if (InventorySlots[i].itemCount < stackLimit)
                    {
                        InventorySlots[i].itemCount++;
                        if (InventorySlots[i].itemCount >= (stackLimit))
                        {
                            InventorySlots[i].isFull = true;

                        }
                        break;


                    }
                    //if (InventorySlots[i].itemCount==0)
                    //{
                    //    InventorySlots[i].itemCount = 0;
                    //    InventorySlots[i].item.ItemPrefab = null;
                    //    InventorySlots[i].isFull = false;

                    //}
                }

            }
            else if (InventorySlots[i].itemCount == 0)
            {
                InventorySlots[i].AddItemToSlot(item);
                break;
            }
        }
       
        
        for (int i = 0; i < InventorySlots.Count; i++)
        {
            for (int j = 1; j < InventorySlots.Count; j++)
            {
                if (InventorySlots[i].item != null && InventorySlots[j].item != null && InventorySlots[i].itemCount != 4 && InventorySlots[j].itemCount != 4)
                {
                    if (InventorySlots[i].item.canStackable)
                    {
                        if ((i + j) < 24)
                        {
                            if (i != (j + i) && i != j && InventorySlots[i].item == InventorySlots[/*i +*/ j].item)
                            {
                                InventorySlots[j].itemCount += InventorySlots[i].itemCount;
                                if (InventorySlots[j].itemCount == 4)
                                {
                                    InventorySlots[j].isFull = true;
                                }
                                //if (InventorySlots[ j].itemCount > 4)
                                //{
                                //    Debug.Log("girdii");
                                //}
                                InventorySlots[i].itemCount = 0;
                                InventorySlots[i].item = null;
                            }
                        }
                    }

                }
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




//foreach (Slot slot in InventorySlots)
//{
//    Debug.Log("item" + item+ "slot.item" + slot.item);

//    if (slot.item == item)
//    {
//        if (slot.item.canStackable)
//        {
//            if (slot.itemCount < stackLimit)
//            {
//                slot.itemCount++;
//                if (slot.itemCount >= (stackLimit))
//                {
//                    slot.isFull = true;
//                }
//                break;
//            }

//        }

//    }
//    else if (slot.itemCount == 0)
//    {
//        slot.AddItemToSlot(item);
//        break;
//    }

//}
