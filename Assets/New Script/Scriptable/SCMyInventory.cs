using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MyInventory", menuName = "Scriptable/MyInventory")]
public class SCMyInventory : ScriptableObject
{
    public List<MySlot> InventorySlots = new List<MySlot>();
    int stackLimit = 4;
    public void AddItem(SCMyItem item)
    {
        InventorySlots.Add(new MySlot() { item = item });
    }

   /* public void AddItem(SCMyItem item)
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
                            if (i != (j + i) && i != j && InventorySlots[i].item == InventorySlots[ j].item)
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




    
}*/
[Serializable]
public class MySlot
{   
    //isFull ve itemcoubnt fazla þuanda
    //public bool isFull;
    //public int itemCount;
    public SCMyItem item;
    public void AddItemToSlot(SCMyItem item)
    {

        this.item = item;
        //if (!item.canStackable)
        //{
        //    isFull = true;

        //}
        //itemCount++;
    }
}



}
