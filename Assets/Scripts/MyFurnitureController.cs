using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFurnitureController : MonoBehaviour
{
     Animator furnitureAnim;
     bool isFurnitureOpen = false;
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
