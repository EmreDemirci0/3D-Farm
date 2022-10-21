using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightDayLoop : MonoBehaviour
{
    [SerializeField] float speed=50;
    void Update()
    {
        //circling the sun to cycle day and night
        transform.RotateAround(new Vector3(30.6f,0,-32.3f),Vector3.right,speed*Time.deltaTime);
    }
}
