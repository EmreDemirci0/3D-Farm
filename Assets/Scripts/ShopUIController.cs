using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{   
    //Market Scriptible Objects items
    public List<SCItem> SCItemList = new List<SCItem>();
    //Market Slots
    public List<SlotUI> SlotUIButtons = new List<SlotUI>();

    private void Start()
    {   
        //Update Shop Method
        UpdateShopUI();
    }
    public void UpdateShopUI()
    {   
        //item in Scriptible Object send slots
        for (int i = 0; i < SCItemList.Count; i++)
        {
            SlotUIButtons[i].itemImage.sprite = SCItemList[i].itemIcon;
            SlotUIButtons[i].itemPriceText.text = SCItemList[i].price.ToString();
        }
        for (int i = SCItemList.Count; i < SlotUIButtons.Count; i++)
        {
            SlotUIButtons[i].itemImage.color = new Color(SlotUIButtons[i].itemImage.color.r, SlotUIButtons[i].itemImage.color.g, SlotUIButtons[i].itemImage.color.b, 0);
            SlotUIButtons[i].itemPriceText.text = null;
            //Boþluklara Basýnca Satýn Almak istiyor musunuz diye sormasýn diye...
           SlotUIButtons[i].gameObject.SetActive(false);
        }
    }
}
