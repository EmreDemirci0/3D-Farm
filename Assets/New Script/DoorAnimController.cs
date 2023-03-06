using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimController : MonoBehaviour
{
    //My Furniture anims
    private Animator DoorAnim;
    //Is the furniture cover open?
    public bool isDoorOpen = false;
    //Animator setbool string
    [SerializeField]private string setboolAnimName = null;
    private void Awake()
    {
        DoorAnim = transform.parent.GetComponent<Animator>();
    }
    public void PlayAnimation(){
        if (!isDoorOpen){
            DoorAnim.SetBool(setboolAnimName, true);
            isDoorOpen = true;
        }
        else{
            DoorAnim.SetBool(setboolAnimName, false);
            isDoorOpen = false;
        }
    }
}
