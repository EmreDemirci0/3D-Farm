using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public bool canStackable;//�st �ste biniyor mu?elma stack'lenir k�l�� stacklenmez
    public Sprite itemIcon;
    public int price;
  
}




////[CreateAssetMenu(fileName = "Animal Item", menuName = "Scriptable/Food")]
//public class SCAnimal : SCItem
//{
//    // public int energy;

//}