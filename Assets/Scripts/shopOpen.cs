using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopOpen : MonoBehaviour
{
    [SerializeField] float raylenght;
    [SerializeField] private Image crosshair = null;
    [SerializeField] private bool isShopOpen;

    [SerializeField] string Aciklama = "";
    public KeyCode openShopPanelKeyCode = KeyCode.Tab;
    public string interactabletag = "";
    public GameObject ShopPanel;
    bool runItOnce=true;//panel aç kapa yaparken cursor sýkýntýlarýný engellemek için cursoru bir kere kapatýyoruz.

    void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>();
        isShopOpen = false;
    }
    void Update()
    {
        HitShop();
    }
    void HitShop()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, raylenght))
        {
            if (hit.collider.gameObject.tag == interactabletag)
            {
                runItOnce = true;
                CrossHairChange(Color.blue);
                if (Input.GetKeyDown(openShopPanelKeyCode))
                {
                    if (isShopOpen)
                    {
                        ShopPanel.SetActive(false);
                        isShopOpen = false;
                        Cursor.visible = false;
                        Cursor.lockState = CursorLockMode.Locked;
                        CrossHairChange(Color.white);
                    }
                    else if (!isShopOpen)
                    {
                        ShopPanel.SetActive(true);
                        isShopOpen = true;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;

                    }
                }
            }
            else
            {
               
               
             
            }

        }
        else
        {
            CrossHairChange(Color.white);
            ShopPanel.SetActive(false);
            if (runItOnce)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                runItOnce = false;
           }

            isShopOpen = false;
        }
    }

    void CrossHairChange(Color colour)
    {
        crosshair.color = colour;
    }
}
