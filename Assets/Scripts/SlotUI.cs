using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlotUI : MonoBehaviour
{
    public Image itemImage;
    public TMPro.TextMeshProUGUI itemPriceText;
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
        // Debug.Log(index+".butona basýldý" + transform.parent.GetChild(index).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text);
        doYouWantToBuyPanel.SetActive(true);
        GetSelectedIndex.SelectedIndex = index;
        
        


    }
}
public class GetSelectedIndex
{   //Seçili Indexi Döndürür. Yani markette týklaðýmýz butonun indexini alýr
    public static int SelectedIndex;
}
