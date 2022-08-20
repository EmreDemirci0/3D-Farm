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
        // Debug.Log(index+".butona bas�ld�" + transform.parent.GetChild(index).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text);
        doYouWantToBuyPanel.SetActive(true);
        GetSelectedIndex.SelectedIndex = index;
        
        


    }
}
public class GetSelectedIndex
{   //Se�ili Indexi D�nd�r�r. Yani markette t�kla��m�z butonun indexini al�r
    public static int SelectedIndex;
}
