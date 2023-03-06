using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "My Item", menuName = "Scriptable/MyItem")]
public class SCMyItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public bool canStackable;//üst üste biniyor mu?elma stack'lenir kýlýç stacklenmez
    public Sprite itemIcon;
    public int price;
    public GameObject ItemPrefab;
}
