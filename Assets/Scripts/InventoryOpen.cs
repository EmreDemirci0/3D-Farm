using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{   
    //Inventory Panel Variable For Panel is Open And Close
    [SerializeField] GameObject InventoryPanel;
    // inventoryPanel is open close control
    /*[HideInInspector]*/public bool isInventoryPanelOpen;
    private void Start()
    {
        //Inventory will initially be closed
        isInventoryPanelOpen = false;
        InventoryPanel.SetActive(false);
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
