using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    [SerializeField] GameObject InventoryPanel;
    bool isInventoryPanelOpen;
    private void Start()
    {
        isInventoryPanelOpen = false;
        InventoryPanel.SetActive(false);
    }
   
    void Update()
    {
        openClosePanel();
    }
    void openClosePanel()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
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
