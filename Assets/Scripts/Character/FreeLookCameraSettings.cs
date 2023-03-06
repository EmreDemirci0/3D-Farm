using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCameraSettings : MonoBehaviour
{

    [Tooltip("0000")]
    [SerializeField] CinemachineFreeLook camera;
    void Start()
    {
        Debug.Log("kamera ayarý");
        camera = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.LeftAlt))
        //{
        //    camera.m_YAxis.m_MaxSpeed = 0f;
        //    Debug.Log("kaldýrdýk");
        //}
        //if (Input.GetKeyDown(KeyCode.LeftAlt))
        //{
        //    camera.m_YAxis.m_MaxSpeed = 1f;
        //    Debug.Log("bastýk");
        //}

    }
}
