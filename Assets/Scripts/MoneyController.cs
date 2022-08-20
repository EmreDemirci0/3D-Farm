using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] int money = 5000;
    [SerializeField] TMPro.TextMeshProUGUI moneyText,  PurchasedText;
    public SCInventory playerInventory;
    BuyItem buyItem = new BuyItem();
    InventoryUIController inventoryUICont;
    private void Start()
    {
        buyItem = GetComponent<BuyItem>();
        inventoryUICont = GetComponent<InventoryUIController>();
        UpdateMoneyText();
        

    }
    private void Update()
    {
        //print("Ad:"+buyItem.item.SCItemList[GetSelectedIndex.SelectedIndex].itemName+"A��klama:" + buyItem.item.SCItemList[GetSelectedIndex.SelectedIndex].itemDescription);
    }

 
    public void SpendMoney(int amount)
    {
        if (money>=amount)
        {
            money -= amount;
            UpdateMoneyText();
            PurchasedText.text = "Satin Alindi";
            //Sat�n Al�nd� Envantere Aktarma Kodunu Yaz
            playerInventory.AddItem(buyItem.ShopUIController.SCItemList[GetSelectedIndex.SelectedIndex]);
            inventoryUICont.UpdateInventoryUI();
        }
        else
        {
            PurchasedText.text = "Yetersiz Bakiye";
        }
       //Bu k�s�mda param�z yok ise �r�n� ald�rmayacak.HALLOLDU
       
    }
    public void WinMoney(int amount)
    {
        UpdateMoneyText();
    }
    public void UpdateMoneyText()
    {
        moneyText.text = money.ToString();
    }
}
