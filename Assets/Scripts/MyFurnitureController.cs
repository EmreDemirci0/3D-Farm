using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFurnitureController : MonoBehaviour
{    
    //My Furniture anims
     Animator furnitureAnim;
    //Is the furniture cover open?
    bool isFurnitureOpen = false;
    //Animator setbool string
    [SerializeField] string setboolAnimName = null;
    private void Awake()
    {
        furnitureAnim = GetComponent<Animator>();
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
