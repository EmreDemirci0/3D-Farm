using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{  //anahatarýn üzerine gelince almýyo bazen
    [Header("Item Controller")]
    [SerializeField]SCMyInventory myInventory;
    [SerializeField] List<SCMyItem> keyMustHave;

    public bool isHaveAllKeys = false;
    public bool isHavePotItems = false;
    public bool isHaveBlackKey = false;
    public bool isHaveCrystalBall = false;
    string p="";
    private void Start()
    {
        UpdateHaveKey();
     
    }
    public void UpdateHaveKey()
    {
        for (int i = 0; i < myInventory.InventorySlots.Count; i++)
            for (int j = 0; j < keyMustHave.Count; j++)
                if (myInventory.InventorySlots[i].item.itemName == keyMustHave[j].itemName)
                    p += myInventory.InventorySlots[i].item.itemName;
        //first note
        if (p.Contains("RedKey")&& p.Contains("GreenKey") && p.Contains("BlueKey") )
            isHaveAllKeys = true;
        else
            isHaveAllKeys=false;
        //third note
        if (p.Contains("Wand") && p.Contains("PurplePotion") && p.Contains("GreenPotion"))
            isHavePotItems = true;
        else
            isHavePotItems = false;
        
        p = "";
        for (int i = 0; i < myInventory.InventorySlots.Count; i++)
        {
            if (myInventory.InventorySlots[i].item.itemName=="BlackKey")
                isHaveBlackKey = true;
            if (myInventory.InventorySlots[i].item.itemName =="CrystalBall")
                isHaveCrystalBall= true;

        }
    }

}
