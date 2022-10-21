using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{   
    //Take Inventory Slots For to transfer from Scriptible object
    public List<InventorySlotUI> InventoryUISlots = new List<InventorySlotUI>();
    //Take Scriptible object For Inventory
    MoneyController userInventory;
    private void Start()
    {   
        
        userInventory = GetComponent<MoneyController>();
        //Updating the inventory after transactions are made in the inventory
        UpdateInventoryUI();
    }
    public void UpdateInventoryUI() 
    {
        for (int i = 0; i < userInventory.playerInventory.InventorySlots.Count; i++)   
        {   
            //if there is an object in scriptible object
            if (userInventory.playerInventory.InventorySlots[i].itemCount > 0)
            {   //Transfer them to UI inventory
                InventoryUISlots[i].itemImage.sprite = userInventory.playerInventory.InventorySlots[i].item.itemIcon;
                InventoryUISlots[i].itemCountText.text = userInventory.playerInventory.InventorySlots[i].itemCount.ToString();
                if (int.Parse(InventoryUISlots[i].itemCountText.text) == 1)
                {
                    InventoryUISlots[i].itemCountText.text = "";
                }
            }
            else
            {   //if there is no object in the scriptible object
                InventoryUISlots[i].itemImage.sprite = null;
                InventoryUISlots[i].itemCountText.text = "";
            }   
              //if the slot is empty,decrease the alpha of your image 
            if (InventoryUISlots[i].itemImage.sprite==null)
                InventoryUISlots[i].itemImage.color = new Color(173,140,69,0.05f);
            else
                InventoryUISlots[i].itemImage.color = new Color(255, 255, 255, 1f);
        }
    }
   
}
