using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteracticeObject : MonoBehaviour
{
//    /**/[SerializeField] private Image crosshair = null;

//    [SerializeField]List<InteractiveObjects> interactiveObjects;
//    float rayLenght = 10;
//    [SerializeField]Transform PlayerHead;
    

   
//    void Start()
//    {
//        crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image     >();
//        for (int i = 0; i < interactiveObjects.Count; i++)
//        {
//            interactiveObjects[i].DoorCollider = GameObject.FindGameObjectWithTag(interactiveObjects[i].interactabletag).transform.GetChild(0).GetComponent<BoxCollider>();
//            interactiveObjects[i].openDoorKey = KeyCode.E;
//        }



//    }

    
//    void Update()
//    {
        
//        openDoor();
//    }
//    void openDoor()
//    {
//        for (int i = 0; i < interactiveObjects.Count; i++)
//        {
//            if (interactiveObjects[i].isOpening)
//            {
//                //Panel oluþtur paneli aktif et
//                print(interactiveObjects[i].interactabletag+"li Kapýmýz Açýlabilir...");
//            }
//        }
        
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        for (int i = 0; i < interactiveObjects.Count; i++)
//        {
//            if (other.gameObject.name == interactiveObjects[0].DoorCollider.name)
//            {
//                interactiveObjects[i].isOpening = true;
//            }
//        }
        

//    }
//    private void OnTriggerExit(Collider other)
//    {
//        for (int i = 0; i < interactiveObjects.Count; i++)
//        {
//            if (other.gameObject.name == interactiveObjects[0].DoorCollider.name)
//            {
//                interactiveObjects[i].isOpening = false;
//            }
//        }

//    }
//}
//[System.Serializable]
//public class InteractiveObjects
//{
    
//    [HideInInspector] public InteractiveController interactiveController;
//    public KeyCode openDoorKey = KeyCode.E;
//   /**/ public BoxCollider DoorCollider;
//    public bool isOpening = false;
//    public string interactabletag = "";
}
