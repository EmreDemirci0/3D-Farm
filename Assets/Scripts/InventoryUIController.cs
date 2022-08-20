using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public List<InventorySlotUI> InventoryUISlots = new List<InventorySlotUI>();
    MoneyController userInventory;
    private void Start()
    {
        userInventory = GetComponent<MoneyController>();
        UpdateInventoryUI();
    }
    public void UpdateInventoryUI()
    {
        Debug.LogError("ENvanter ve Marketi ayna anda açýnca bug olay");
        for (int i = 0; i < userInventory.playerInventory.InventorySlots.Count; i++)
        {
            if (userInventory.playerInventory.InventorySlots[i].itemCount > 0)
            {
                InventoryUISlots[i].itemImage.sprite = userInventory.playerInventory.InventorySlots[i].item.itemIcon;
                InventoryUISlots[i].itemCountText.text= userInventory.playerInventory.InventorySlots[i].itemCount.ToString();
            }
        }
    }
   
}
