using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuyItem : MonoBehaviour
{   
    //Do you want to buy Panel Take with Inspector For Panel is Open and Close
    [SerializeField] GameObject doYouWantToBuyPanel;
    //Purchased Panel With Inspector For Panel is Open and Close
    [SerializeField] GameObject Purchased;
    //Reaching The MoneyController Script For Spend Money
    [SerializeField] MoneyController moneyController;
    //Reaching The ShopUIController  Script For Choose Which Object
    public ShopUIController ShopUIController;
    
    private void Start()
    {
        //ShopUIController Take with Start Method
        ShopUIController = GetComponent<ShopUIController>();
        //MoneyController Take with Start Method
        moneyController = GetComponent<MoneyController>();
        //Do You Want To Buy Panel Will be Closed
        doYouWantToBuyPanel.SetActive(false);
        //Purchased Panel Will be Closed
        Purchased.gameObject.SetActive(false);
    }
    public void ClickBuyYesButton()//If Do You Want to Buy is Yes
    {
        //deduct as much money as the product price from the main money
        moneyController.SpendMoney(int.Parse(ShopUIController.SlotUIButtons[GetSelectedIndex.SelectedIndex].itemPriceText.text));
        //Do You Want To Buy Panel Will be Closed
        doYouWantToBuyPanel.SetActive(false);
        //Purchased Panel Will be Closed
        Purchased.gameObject.SetActive(true);
       
       
    }
    public void ClickBuyNoButton()//If Do You Want to Buy is Yes
    {
        //Do You Want To Buy Panel Will be Closed
        doYouWantToBuyPanel.SetActive(false);
    }
    public void ClosePurchasedPanelClick()//"Satin Alýndý" Text Under Button Click event
    {
        //Purchased Panel Will be Closed
        Purchased.gameObject.SetActive(false);

    }
    
   
}
