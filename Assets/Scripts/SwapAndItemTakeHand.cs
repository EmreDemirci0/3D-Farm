using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwapAndItemTakeHand : MonoBehaviour
{  
    [Header("For Button")]
    //Reaching Scriptible object's content
    public SCInventory playerInventory;
 
    //For Update inventory and border for selected object 
    public InventoryUIController inventoryUICont;

    //Item Take In Hand
    ItemTakeInHand itemTakeInHand;

    //item take in hand index
    public int itemTakeInHandIndex;

    //Swap variables
    bool isSwaping;
    int tempIndex;
    Slot tempSlot;

    Image Cursor;
    private void Start()
    {
        inventoryUICont = GetComponent<InventoryUIController>();
        itemTakeInHand = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ItemTakeInHand>();
      //  for (int i = 0; i < 6; i++)
      //  {
      //      if (playerInventory.InventorySlots[i].item.ItemPrefab==null)
       //     {
                itemTakeInHand.SetItem(playerInventory.InventorySlots[0].item.ItemPrefab);
//
     //       }
     //   }
       

        Cursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<Image>();
        Cursor.gameObject.SetActive(false);
    }
    private void Update()
    {
        Cursor.transform.position = Input.mousePosition;
    }
    public void CurrentItem(int index) //Item Take in Hand
    {
        itemTakeInHandIndex = index;
        //Ýf Take In Hand Item,Take that item
        if (playerInventory.InventorySlots[index].item)
        {
            itemTakeInHand.SetItem(playerInventory.InventorySlots[index].item.ItemPrefab);
            itemTakeInHand.ItemHolderPoint.SetActive(true);
        }
        else
        {
            itemTakeInHand.currentItem = null;
            if (itemTakeInHand.currentItem == null)
                itemTakeInHand.ItemHolderPoint.SetActive(false);

        }
        if (index >= 0 && index < 6)//Give a border to the slot we pressed in the hotbar
        {

            for (int i = 0; i < 6; i++)
            {
                inventoryUICont.InventoryUISlots[i].gameObject.transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(false);
            }
            inventoryUICont.InventoryUISlots[index].gameObject.transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(true);

        }

    }
    public void SwapItem(int index)//Swap item
    {
        if ((tempIndex >= 0 && tempIndex < 6) && (index >= 0 && index < 6)) //No swap in hotbar
            return;

        //if the other object we want to swap is empty logo is dont show
        if (playerInventory.InventorySlots[index].itemCount==0)
            Cursor.gameObject.SetActive(false);
        else//if the other object we want to swap is not empty  that is, if there is an object in the slot
        {
            if (index>5)//dont show object in hotbar
            {
                Cursor.sprite = playerInventory.InventorySlots[index].item.itemIcon;
                Cursor.gameObject.SetActive(true);
            }
        }
        // swap 
        if (!isSwaping)
        {
            tempIndex = index;
            tempSlot = playerInventory.InventorySlots[tempIndex];
            isSwaping = true;
        }
        else if (isSwaping)
        {
            playerInventory.InventorySlots[tempIndex] = playerInventory.InventorySlots[index];
            playerInventory.InventorySlots[index] = tempSlot;
            isSwaping = false;
            Cursor.gameObject.SetActive(false);
        }
        inventoryUICont.UpdateInventoryUI();


    }
}
