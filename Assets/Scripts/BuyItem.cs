using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuyItem : MonoBehaviour
{
    [SerializeField] GameObject doYouWantToBuyPanel;
    [SerializeField] MoneyController moneyController;
    [SerializeField] GameObject Purchased;
    /**/ //public Item item;
    /**/
    public ShopUIController ShopUIController;
    
    private void Start()
    {
        ShopUIController = GetComponent<ShopUIController>();
     
        doYouWantToBuyPanel.SetActive(false);
       
        moneyController = GetComponent<MoneyController>();
        Purchased.gameObject.SetActive(false);
    }
    private void Update()
    {
        Debug.LogWarning(ShopUIController.SlotUIButtons[GetSelectedIndex.SelectedIndex].itemPriceText.text);
    }
    public void ClickBuyYesButton()
    {
        moneyController.SpendMoney(int.Parse(ShopUIController.SlotUIButtons[GetSelectedIndex.SelectedIndex].itemPriceText.text));
        doYouWantToBuyPanel.SetActive(false);
        
        Purchased.gameObject.SetActive(true);
       
       
    }
    public void ClosePurchasedPanelClick()
    {
        Purchased.gameObject.SetActive(false);

    }
    public void ClickBuyNoButton()
    {
        doYouWantToBuyPanel.SetActive(false);
    }
   
}
