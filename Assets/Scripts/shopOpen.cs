//boþþþþþþþþþþþþþþþþþþþþþþþþþþþþ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopOpen : MonoBehaviour
{   
    //FarmLanda Gelince crossta bug var
    [SerializeField] float raylenght;
    [HideInInspector] public bool isShopOpen;

    [SerializeField]List<shopOpenClass> shopOpenClass = new List<shopOpenClass>();

    bool runItOnce = true;//panel aç kapa yaparken cursor sýkýntýlarýný engellemek için cursoru bir kere kapatýyoruz.
    RayCastDeneme rcd;
    void Start()
    {
        rcd = GetComponent<RayCastDeneme>();
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
        for (int i = 0; i < shopOpenClass.Count; i++)
        {
            if (Physics.Raycast(transform.position, fwd, out hit, raylenght))
            {

                if (hit.collider.gameObject.tag == shopOpenClass[i].interactabletag)
                {
                    runItOnce = true;
                    rcd.CrosshairChange(true,/* shopOpenClass[i].colour*/Color.blue);
                    if (Input.GetKeyDown(shopOpenClass[i].openShopPanelKeyCode))
                    {
                        if (isShopOpen)
                        {
                            shopOpenClass[i].ShopPanel.SetActive(false);
                            isShopOpen = false;
                            Cursor.visible = false;
                            Cursor.lockState = CursorLockMode.Locked;
                            rcd.CrosshairChange(false,/* shopOpenClass[i].colour*/Color.blue);
                        }
                        else if (!isShopOpen)
                        {
                            shopOpenClass[i].ShopPanel.SetActive(true);
                            isShopOpen = true;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;

                        }
                    }
                }
            }



            else
            {
                rcd.CrosshairChange(false, /*shopOpenClass[i].colour*/Color.blue);
                shopOpenClass[i].ShopPanel.SetActive(false);
                if (runItOnce)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    runItOnce = false;
                }

                isShopOpen = false;
            }
        }
    }

    //void CrossHairChange(Color colour)
    //{
    //    crosshair.color = colour;
    //}
}
[System.Serializable]
class shopOpenClass
{
    [SerializeField] string Aciklama = "";
    public KeyCode openShopPanelKeyCode = KeyCode.Tab;
    public string interactabletag = "";
    public GameObject ShopPanel;
   // public Color colour;
}