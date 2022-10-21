using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{   
    //Inventory Panel Variable For Panel is Open And Close
    [SerializeField] GameObject InventoryPanel;
    // inventoryPanel is open close control
    /*[HideInInspector]*/public bool isInventoryPanelOpen;
    //shopOpen With Inspector For Inventory Wont Open when market is open
    ObjectOpenClose isShopOpen;
    private void Start()
    {
        //Inventory will initially be closed
        isInventoryPanelOpen = false;
        InventoryPanel.SetActive(false);
        //shopOpen Take with Start Method
        isShopOpen = GetComponent<ObjectOpenClose>();
    }

    void Update()
    {   
        //Panel is Open Close Control and Click Key
        openClosePanel();
    }
    void openClosePanel()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isShopOpen.isShopOpen)//Market Açýkken envanter açýlmaz.
            {   
                //If inventory open Cursor is Open
                if (isInventoryPanelOpen)
                {
                    InventoryPanel.SetActive(false);
                    isInventoryPanelOpen = false;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;

                }
                else if (!isInventoryPanelOpen)
                {
                    InventoryPanel.SetActive(true);
                    isInventoryPanelOpen = true;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;

                }
            }
        }
    }
}
