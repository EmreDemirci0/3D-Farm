using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFurnitureController : MonoBehaviour
{    
    //My Furniture anims
    [SerializeField]Animator furnitureAnim;
    //Is the furniture cover open?
    bool isFurnitureOpen = false;
    //Animator setbool string
    [SerializeField] string setboolAnimName = null;
    //[SerializeField]BoxCollider thisCollider;
    private void Awake()
    {
        furnitureAnim = GetComponent<Animator>();
       // thisCollider = transform.GetChild(0).GetComponent<BoxCollider>();
    }
    public void PlayAnimation()
    {
        if (!isFurnitureOpen)
        {
            furnitureAnim.SetBool(setboolAnimName, true);
            isFurnitureOpen = true;
        }
        else 
        {
            furnitureAnim.SetBool(setboolAnimName, false);
            isFurnitureOpen = false;
        }
    }
}
