using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlotUI : MonoBehaviour
{   
    
    public Image itemImage;
    public TMPro.TextMeshProUGUI itemPriceText;
    //Asks Yes or No panel
    [SerializeField]GameObject doYouWantToBuyPanel;
    private void Start()
    {
        doYouWantToBuyPanel.SetActive(false);
    }
    private void Update()
    {
        

    }
    public void ClickBuyButton(int index)
    {
        doYouWantToBuyPanel.SetActive(true);
        GetSelectedIndex.SelectedIndex = index;
    }
}
public class GetSelectedIndex
{   //Seçili Indexi Döndürür. Yani markette týklaðýmýz butonun indexini alýr
    public static int SelectedIndex;
}
