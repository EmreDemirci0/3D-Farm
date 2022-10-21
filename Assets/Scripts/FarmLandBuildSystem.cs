//SÝLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandBuildSystem : MonoBehaviour
{
    public Vector3 place;
    private RaycastHit hit;
    public GameObject objectToPlace, tempObject;
    public GameObject FarmlandArea, FarmlandAreaDontMesh;
    public bool placeNow;
    public bool placeFarmLand;
    public bool tempObjectExists;
    private void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 15))
        {
            Debug.Log("hit:" + hit.point.x+ hit.point.y+ hit.point.z+"");
        }
        //if (placeNow)
        //{
        //    SendRay();
        //}
        //if (placeFarmLand)
        //{
        //    objectToPlace = FarmlandArea;
        //}
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    PlaceFarmLand();
        //}
    }
    public void SendRay()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 15))
        {
            place = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            if (hit.transform.tag == "Floor")
            {
                if (!tempObjectExists)
                {

                    tempObject = Instantiate(FarmlandAreaDontMesh, place, Quaternion.identity);
                    // tempObject = GameObject.Find("Farmland Large(Clone)");
                    tempObjectExists = true;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(objectToPlace, place, Quaternion.identity);
                    placeNow = false;
                    placeFarmLand = false;

                    Destroy(tempObject);
                    tempObjectExists = false;
                }
                if (tempObject != null)
                {
                    tempObject.transform.position = place;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                placeNow = false;
                placeFarmLand = false;

                Destroy(tempObject);
                tempObjectExists = false;
            }
        }
    }
    public void PlaceFarmLand()
    {
        placeNow = true;
        placeFarmLand = true;
    }
}
