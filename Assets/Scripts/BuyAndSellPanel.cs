using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyAndSellPanel : MonoBehaviour
{   
    //Buy Panel,Sell Panel and Main Panel take with Inspector
    [SerializeField] GameObject BuyPanel, SellPanel,MainPanel;
    public void BuyButton()
    {   
        //Buy Panel Will be Opened
        BuyPanel.SetActive(true);
        //Sell Panel Will be Closed
        SellPanel.SetActive(false);
    }
    public void SellButton()
    {
        //Buy Panel Will be Closed
        BuyPanel.SetActive(false);
        //Sell Panel Will be Opened
        SellPanel.SetActive(true);
    }

}
