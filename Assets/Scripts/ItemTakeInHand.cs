using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTakeInHand : MonoBehaviour
{
    //item in my hand Gameobject
    public GameObject currentItem;
    //the point where the item will spawn in my hand
    public GameObject ItemHolderPoint;
    //Temp object for in my hand item
    GameObject temp = null;
    public void SetItem(GameObject Item)
    {
        currentItem = Item;
        //if we get more than one item,we delete the previous on so that it does not overlap
        if (temp)
            Destroy(temp.gameObject);
        //in Item Holder Point Instantiate Object and position is v.zero
        temp = Instantiate(currentItem, ItemHolderPoint.transform);
        temp.transform.localPosition = Vector3.zero;
    }
    public GameObject getItem()
    {
        return currentItem;
    }


}

