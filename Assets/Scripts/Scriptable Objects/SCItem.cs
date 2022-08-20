using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public bool canStackable;//üst üste biniyor mu?elma stack'lenir kýlýç stacklenmez
    public Sprite itemIcon;
    public int price;
  
}




////[CreateAssetMenu(fileName = "Animal Item", menuName = "Scriptable/Food")]
//public class SCAnimal : SCItem
//{
//    // public int energy;

//}