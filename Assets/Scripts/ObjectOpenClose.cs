using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOpenClose : MonoBehaviour
{
    //FarmLanda Gelince crossta bug var
    [SerializeField] float raylenght;
    [HideInInspector] public bool isShopOpen;

    [SerializeField] List<ObjectOpenCloseClass> objectOpenCloseClass = new List<ObjectOpenCloseClass>();

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
        for (int i = 0; i < objectOpenCloseClass.Count; i++)
        {
            if (Physics.Raycast(transform.position, fwd, out hit, raylenght))
            {

                if (hit.collider.gameObject.tag == objectOpenCloseClass[i].interactabletag)
                {
                    runItOnce = true;
                    rcd.CrosshairChange(true,Color.blue);
                    if (Input.GetKeyDown(objectOpenCloseClass[i].openShopPanelKeyCode))
                    {
                        if (isShopOpen)
                        {
                            objectOpenCloseClass[i].ShopPanel.SetActive(false);
                            isShopOpen = false;
                            Cursor.visible = false;
                            Cursor.lockState = CursorLockMode.Locked;
                            rcd.CrosshairChange(false,Color.blue);
                        }
                        else if (!isShopOpen)
                        {
                            objectOpenCloseClass[i].ShopPanel.SetActive(true);
                            isShopOpen = true;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;

                        }
                    }
                }
            }



            else
            {
                rcd.CrosshairChange(false, Color.blue);
                objectOpenCloseClass[i].ShopPanel.SetActive(false);
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

}
[System.Serializable]
class ObjectOpenCloseClass
{
    [SerializeField] string Aciklama = "";
    public KeyCode openShopPanelKeyCode = KeyCode.Tab;
    public string interactabletag = "";
    public GameObject ShopPanel;
   
}