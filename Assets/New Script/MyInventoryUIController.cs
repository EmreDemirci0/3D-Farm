using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyInventoryUIController : MonoBehaviour
{
    //Take Inventory Slots For to transfer from Scriptible object
    public List<InventorySlotUI> MyInventoryUISlots = new List<InventorySlotUI>();
    //Take Scriptible object For Inventory
    [SerializeField]SCMyInventory MyUserInventory;
    GameObject ImportantBorderSlot;
    [SerializeField] Sprite ImportantBorder;
    private void Start()
    {
        UpdatesInventoryUI();
    }
    public void UpdatesInventoryUI()
    {
        for (int i = 0; i < MyUserInventory.InventorySlots.Count; i++)
        {
            if (MyUserInventory.InventorySlots[i].item.itemName=="CrystalBall" )
            {   //CrystallBall Adding Border;
                ImportantBorderSlot=MyInventoryUISlots[i].gameObject;
                GameObject ImportantBorderGameobject = new GameObject("Border");
                ImportantBorderGameobject.transform.parent = ImportantBorderSlot.transform;
                ImportantBorderGameobject.AddComponent<CanvasRenderer>();
                ImportantBorderGameobject.AddComponent<Image>().sprite=ImportantBorder;
                ImportantBorderGameobject.GetComponent<RectTransform>().localScale = new Vector3(1.4f,1.4f);
                ImportantBorderGameobject.GetComponent<RectTransform>().localPosition = Vector3.zero;
            }
            MyInventoryUISlots[i].itemImage.sprite = MyUserInventory.InventorySlots[i].item.itemIcon;
            MyInventoryUISlots[i].itemCountText.text = MyUserInventory.InventorySlots[i].item.itemName.ToString();
            MyInventoryUISlots[i].itemCountText.text = "";
            if (MyInventoryUISlots[i].itemImage.sprite == null)
                MyInventoryUISlots[i].itemImage.color = new Color(173, 140, 69, 0.05f);
            else
                MyInventoryUISlots[i].itemImage.color = new Color(255, 255, 255, 1f);
        }
    }
}
