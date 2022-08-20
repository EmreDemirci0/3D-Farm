using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyAndSellPanel : MonoBehaviour
{
    [SerializeField] GameObject BuyPanel, SellPanel,MainPanel;
     Image BuyImage, SellImage;
    void Start()
    {
        BuyImage = BuyPanel.GetComponent<Image>();
        SellImage = SellPanel.GetComponent<Image>();

    }

    public void BuyButton()
    {
        //MainPanel.SetActive(true);
        BuyPanel.SetActive(true);
        SellPanel.SetActive(false);


        //Color temp = SellImage.color;
        //temp.a = 0f;
        //SellImage.color = temp;

        //Color temps = BuyImage.color;
        //temps.a = 1f;
        //BuyImage.color = temps;

    }
    public void SellButton()
    {
        //MainPanel.SetActive(true);
        BuyPanel.SetActive(false);
        SellPanel.SetActive(true);
        //Color temp = BuyImage.color;
        //temp.a = 0f;
        //BuyImage.color = temp;

        //Color temps = SellImage.color;
        //temps.a = 1f;
        //SellImage.color = temps;
    }

}
