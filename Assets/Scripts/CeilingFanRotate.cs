using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingFanRotate : MonoBehaviour
{   
    //For Ceiling Fan Rotate, Rotate Vector Variable
    public Vector3 rotateVector = new Vector3(0, 0, 1);
    //For Ceiling Fan Rotate, Rotate Speed Variable
    public float speed = 50;
    void Update()
    {   
        //Ceiling Fan Rotate own Axis Method
        transform.Rotate(rotateVector * speed * Time.fixedDeltaTime);
    }
}
