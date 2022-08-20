using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightDayLoop : MonoBehaviour
{
    [SerializeField] float speed=50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3(30.6f,0,-32.3f),Vector3.right,speed*Time.deltaTime);
    }
}
