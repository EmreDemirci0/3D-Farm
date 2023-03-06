using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ÇEKMECELER İÇİN MESHCOLLİDER'İ İNAKTİF YAPIP SADECE ÇEKMECE BAŞINA BOX COLLİDER KOYABİLİRİZ
public class DeskLamp : MonoBehaviour
{
    //Reaching the bottom "DeskLampController" class with list
    [SerializeField] List<DeskLampController> deskLampControllers = new List<DeskLampController>();
    //Cross On Screen
    private Image crosshair = null;
    //Distance needed see the object
    [SerializeField] float rayLength = 5;
    
    private bool isCrosshairActive;

    private bool doOnce;
    
    private void Start()
    {
        //Find CrossHair With Tag
        crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>();
    }
    private void Update()
    {   
        //RayCastHit Variable
        RaycastHit hit;
        //RayCastHit Direction
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //Right In Front Of Our transform  And Is There Any Object With Tagged Lenght
        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {   
            //List Control
            for (int i = 0; i < deskLampControllers.Count; i++)
            {   
                // Dois it Meet Our Tag
                if (hit.collider.gameObject.tag == deskLampControllers[i].interactabletag)
                {   
                    //Set Lamp Key
                    deskLampControllers[i].openLampKey = KeyCode.Mouse0;
                    if (!doOnce)
                    {   
                        //Find Lamp
                        deskLampControllers[i].Light = GameObject.FindGameObjectWithTag(deskLampControllers[i].lampTag).GetComponent<Light>();
                        //Cross Change
                        CrosshairChange(true);
                    }
                    isCrosshairActive = true;
                    doOnce = false; 
                    //If we Press the key we give
                    if (Input.GetKeyDown(deskLampControllers[i].openLampKey))
                    {   
                        //If lamp is Open,Close
                        if (deskLampControllers[i].Light.isActiveAndEnabled)
                        {
                            deskLampControllers[i].Light.enabled = (false);
                        }
                        //Else lamp is Close,Open
                        else
                        {
                            deskLampControllers[i].Light.enabled = (true);
                        }
                    }
                }
                //This Elif For Change cross
                else if (hit.collider.gameObject.tag == "Untagged")
                {
                    CrosshairChange(false);
                }
            }
        }
        else//İf my character not looking at anyting and my cross Active,Do Cross restore
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }

    }
    void CrosshairChange(bool on)//Cross Change
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
    //For Single Script with multiple Object control there is this Class 
    [SerializeField] string Aciklama = "";
    public KeyCode openLampKey = KeyCode.Mouse0;
    public Light Light;
    public string lampTag = "";
    public string interactabletag = "";
}



