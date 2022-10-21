using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[DefaultExecutionOrder]
public class FarmLandBuildSystems : MonoBehaviour
{
    //define variables main object and temp objects
    public GameObject main, temp;
    //define variables for instantiate position
    Vector3 InstantiatePos;
    //RayCastHit variables
    RaycastHit hit;
    //if scene is have a temp object dont instatiate
    /**/
    [SerializeField] bool placeJustaPiece;
    /*now empty*/
    [SerializeField] bool isPlace;

    [SerializeField] float rayLenght;//raylen
    ItemTakeInHand itemTakeInHandC;
    InventoryOpen isInventoryPanelOpenControl;
    SwapAndItemTakeHand swapAndItemTakeHand;
    InventoryUIController InventoryUIController;
    private void Start()
    {
        placeJustaPiece = true;
        isPlace = false;
        itemTakeInHandC = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ItemTakeInHand>();
        isInventoryPanelOpenControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<InventoryOpen>();
        swapAndItemTakeHand = GameObject.FindGameObjectWithTag("BuyInventoryContent").GetComponent<SwapAndItemTakeHand>();
        InventoryUIController = GameObject.FindGameObjectWithTag("BuyInventoryContent").GetComponent<InventoryUIController>();
        Debug.LogError("swap için ürün seçince ve sdonra envanter kapayýnca bug oluyo");

    }
    private void Update()
    {
        PlaceObjectControls();
        //burdayýz
        // itemTakeInHandC.getItem().GetComponent<>;
        //    swapAndItemTakeHand.playerInventory.InventorySlots[0].itemCount = 0;

    }

    void PlaceObjectControls()
    {
        if (!isInventoryPanelOpenControl.isInventoryPanelOpen)
            if (itemTakeInHandC.getItem() && itemTakeInHandC.getItem().GetComponent<MeshFilter>() && main.GetComponent<MeshFilter>())
                if (itemTakeInHandC.getItem().GetComponent<MeshFilter>().sharedMesh == main.GetComponent<MeshFilter>().sharedMesh)
                    PlaceObj();
        if (itemTakeInHandC.currentItem)
        {
            Debug.Log("birþey var");
        }

    }
    private void PlaceObj()
    {
        //raycast but mouse position
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, rayLenght))
        {

            if (hit.transform.tag == "Floor")
            {
                if (GameObject.Find("farmland_large_dontmest(Clone)") != null)
                {
                    GameObject.Find("farmland_large_dontmest(Clone)").transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;

                }
                //take where we look and assign variables
                InstantiatePos = new Vector3(hit.point.x, hit.point.y + 0.07f, hit.point.z);
                if (placeJustaPiece)
                {
                    //instatiate temp(without mesh) wherever we want show me
                    if (swapAndItemTakeHand.playerInventory.InventorySlots[swapAndItemTakeHand.itemTakeInHandIndex].item)
                    {
                        if (swapAndItemTakeHand.playerInventory.InventorySlots[swapAndItemTakeHand.itemTakeInHandIndex].item.ItemPrefab == itemTakeInHandC.getItem())
                        {
                            Instantiate(temp, InstantiatePos, Quaternion.identity);
                            placeJustaPiece = false;
                        }
                    }
                }

                Debug.Log("swap.index" + swapAndItemTakeHand.playerInventory.InventorySlots.Count/* swapAndItemTakeHand.playerInventory.InventorySlots[4].item.itemName*/);


                // else Debug.Log("kdkdk");


                //find temp(without mesh) and equals to instatiate pos
                if (GameObject.Find("farmland_large_dontmest(Clone)"))
                {
                    GameObject.Find("farmland_large_dontmest(Clone)").transform.position = InstantiatePos;
                    //if i click mouse left destroy temp(without mesh) and instantiate main(with mesh)
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Destroy(GameObject.Find("farmland_large_dontmest(Clone)").gameObject);
                        if (swapAndItemTakeHand.playerInventory.InventorySlots[swapAndItemTakeHand.itemTakeInHandIndex].item)
                        {
                            if (swapAndItemTakeHand.playerInventory.InventorySlots[swapAndItemTakeHand.itemTakeInHandIndex].item.ItemPrefab == itemTakeInHandC.getItem())
                            {
                                swapAndItemTakeHand.playerInventory.InventorySlots[swapAndItemTakeHand.itemTakeInHandIndex].itemCount = 0;
                                swapAndItemTakeHand.playerInventory.InventorySlots[swapAndItemTakeHand.itemTakeInHandIndex].item = null;
                                swapAndItemTakeHand.playerInventory.InventorySlots[swapAndItemTakeHand.itemTakeInHandIndex].isFull = false;
                                //                    swapAndItemTakeHand.inventoryUICont.InventoryUISlots[swapAndItemTakeHand.itemTakeInHandIndex].itemImage = null;
                                //                   swapAndItemTakeHand.inventoryUICont.InventoryUISlots[swapAndItemTakeHand.itemTakeInHandIndex].itemCountText.text=0.ToString();
                                InventoryUIController.UpdateInventoryUI();
                                Instantiate(main, InstantiatePos, Quaternion.identity);
                                placeJustaPiece = true;
                                isPlace = true;
                                Debug.Log("saldý");
                                itemTakeInHandC.ItemHolderPoint.SetActive(false);
                                //Destroy(GameObject.Find("farmland_large_dontmest(Clone)").gameObject);
                            }
                        }
                       

                    }
                   
                }
               


            }
            else
            {
                if (GameObject.Find("farmland_large_dontmest(Clone)"))
                {
                    GameObject.Find("farmland_large_dontmest(Clone)").transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                }
            }



        }

    }
}
