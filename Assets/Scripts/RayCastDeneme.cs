using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ÇEKMECELER İÇİN MESHCOLLİDER'İ İNAKTİF YAPIP SADECE ÇEKMECE BAŞINA BOX COLLİDER KOYABİLİRİZ
public class RayCastDeneme : MonoBehaviour
{
    [SerializeField]private List<raycastTurleri> raycastTuru = new List<raycastTurleri>();
    private Image crosshair = null;
    [SerializeField] float rayLength = 5;
    private bool doOnce;
    private bool isCrosshairActive;
    private void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>();

    }
    private void Update()
    {
        
        RaycastHit hit;
        
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        //for (int i = 0; i < raycastTuru.Count; i++)
        //{
        //    //  int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | LayerMaskInteract.value;
        //}

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            
            for (int i = 0; i < raycastTuru.Count; i++)
            {
             
                if (hit.collider.gameObject.tag == raycastTuru[i].interactabletag)
                {
                    if (!doOnce)
                    {   
                        raycastTuru[i].raycastedObj = hit.collider.gameObject.GetComponent<MyFurnitureController>();

                        CrosshairChange(true, Color.red);

                    }
                    isCrosshairActive = true;
                    doOnce = false;
                    if (Input.GetKeyDown(raycastTuru[i].openDoorKey))
                    {
                        raycastTuru[i].raycastedObj.PlayAnimation();
                    }
                    break;
                }
                else if(hit.collider.gameObject.tag=="Untagged")
                {
                    CrosshairChange(false, Color.red);
                }

            }

        }
        else
        {

            if (isCrosshairActive)
            {
                CrosshairChange(false,Color.red);
                doOnce = false;
            }

        }

    }
    //Main Cross Change Color Method
   public void CrosshairChange(bool on,Color colour)
    {
        if (on && !doOnce)
        {
            crosshair.color = colour;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }

}
[System.Serializable]
public class raycastTurleri
{
    [SerializeField] string Aciklama = "";
    [HideInInspector]public MyFurnitureController raycastedObj;
    public KeyCode openDoorKey = KeyCode.Mouse0;
    public string interactabletag = "";
}

