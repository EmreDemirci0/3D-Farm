using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //[SerializeField] GameObject Player;
    //[SerializeField] GameObject Cam;
    //[SerializeField] Rigidbody rb;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    Player.GetComponent<PlayerController>().enabled = false;
    //    Player.GetComponent<CharacterController>().enabled = false;
    //    //Player.transform.GetChild(2).transform.GetChild(0).GetComponent<MouseLook>().enabled = false;
    //    //Player.transform.GetChild(2).transform.GetChild(0).GetComponent<Transform>().rotation = transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
    //    Cam.transform.eulerAngles += new Vector3(0,270,0); 
    //    Player.transform.parent = this.GetComponent<Transform>();
    //    Player.transform.localPosition = Vector3.zero;
    //    Player.transform.localRotation = Quaternion.Euler(Vector3.zero);
        
    //    Player.transform.localPosition += new Vector3(-.378f,.35f,0);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    float horizontal = Input.GetAxis("Horizontal");
    //    float vertical = Input.GetAxis("Vertical");

    //    Vector3 forward = Cam.transform.forward;
    //    forward.y = 0f;
    //    forward = forward.normalized;

    //    Vector3 right = Cam.transform.right;
    //    right.y = 0f;
    //    right = right.normalized;

    //    Vector3 direction = (forward * vertical) + (right * horizontal);
    //    rb.MovePosition(rb.position + direction *10* Time.deltaTime);

    //}
}
