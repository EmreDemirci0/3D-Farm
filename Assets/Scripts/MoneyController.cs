using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyController : MonoBehaviour//Envantere Aktarma Kodu burada
{
    //My General Shop Money      
    [SerializeField] int money = 5000;
    //moneyText variable where money is displayed on the screen
    [SerializeField] TextMeshProUGUI moneyText;
    //after purchase text exp:satýn alýndý,yetersiz bakiye
    [SerializeField] TextMeshProUGUI PurchasedText;
    //Reaching Scriptible object's content
    public SCInventory playerInventory;
    // to add items to the inventory
    BuyItem buyItem;
    //For Update inventory and border for selected object 
    InventoryUIController inventoryUICont;
   

    private void Start()
    {
        buyItem = GetComponent<BuyItem>();
        inventoryUICont = GetComponent<InventoryUIController>();
        UpdateMoneyText();//Money Update Text
    }
   


    public void SpendMoney(int amount)//if we buy products the money will be less
    {
        if (money >= amount)//if we have money,Buy
        {
            money -= amount;
            UpdateMoneyText();
            PurchasedText.text = "Satin Alindi";
            //Satýn Alýndý Envantere Aktarma Kodunu Yaz
            playerInventory.AddItem(buyItem.ShopUIController.SCItemList[GetSelectedIndex.SelectedIndex]);
            inventoryUICont.UpdateInventoryUI();

        }
        else// if we dont have money, dont Buy
        {
            PurchasedText.text = "Yetersiz Bakiye";
        }
 

    }
    public void WinMoney(int amount)//win money
    {
        UpdateMoneyText();
    }
    public void UpdateMoneyText()//Money Text Update
    {
        moneyText.text = money.ToString();
    }
}
