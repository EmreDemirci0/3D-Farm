using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ÇEKMECELER İÇİN MESHCOLLİDER'İ İNAKTİF YAPIP SADECE ÇEKMECE BAŞINA BOX COLLİDER KOYABİLİRİZ
public class DeskLamp : MonoBehaviour
{
    [SerializeField] List<DeskLampController> deskLampControllers = new List<DeskLampController>();

    private Image crosshair = null;
    [SerializeField] float rayLength = 5;
    private bool isCrosshairActive;
    private bool doOnce;
    
    private void Start()
    {
      
       
        crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>();

        for (int i = 0; i < deskLampControllers.Count; i++)
        {

            
        }



    }
    private void Update()
    {
       
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            for (int i = 0; i < deskLampControllers.Count; i++)
            {
                if (hit.collider.gameObject.tag == deskLampControllers[i].interactabletag)
                {
                    deskLampControllers[i].openLampKey = KeyCode.Mouse0;
                    if (!doOnce)
                    {
                        deskLampControllers[i].Light = GameObject.FindGameObjectWithTag(deskLampControllers[i].lampTag).GetComponent<Light>();
                     
                        CrosshairChange(true);
                    }
                    isCrosshairActive = true;
                    doOnce = false;
                    if (Input.GetKeyDown(deskLampControllers[i].openLampKey))
                    {
                        if (deskLampControllers[i].Light.isActiveAndEnabled)
                        {
                            deskLampControllers[i].Light.enabled = (false);
                        }
                        else
                        {
                            deskLampControllers[i].Light.enabled = (true);

                        }

                        print("Lamba kapatıldı....");


                    }
                }
                else if (hit.collider.gameObject.tag == "Untagged")
                {
                    CrosshairChange(false);
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }

    }
    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }

}
[System.Serializable]
public class DeskLampController
{
    [SerializeField] string Aciklama = "";
    public KeyCode openLampKey = KeyCode.Mouse0;
    public Light Light;
    public string lampTag = "";
    public string interactabletag = "";
}



