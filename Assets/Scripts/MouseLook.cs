using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{   
    //Mouse Sensivity
    [Range(20, 500)] [SerializeField] private float sens;
    //Character Body
    [SerializeField] Transform body;
    //Player Properties
    [SerializeField] PlayerController playerScript;

    float xRot = 0;
    [SerializeField] Transform leaner;
    float zRot;
    public static bool isRotating;//playerController.cs'de static olarak kullanıyoruz

    [SerializeField] float smoothing = 40;
    public float currentRot;

    private void Start()
    {
        xRot = 0;
        //no cursor when the game starts
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void Update()
    {
        //Keep cursor on when market or inventory is open
        if (Cursor.visible == false && Cursor.lockState == CursorLockMode.Locked)
        {
            CameraMovement();
            CameraLean();
        }




    }
    private void CameraMovement()//Camera Events
    {
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;

        xRot -= rotY;   //Burada xRot en ba�ta 0 fareyi yukar� kayd�r�nca yani rotY yi hareket ettirince

        xRot = Mathf.Clamp(xRot, -80f, 80f);

        currentRot += rotX;

        currentRot = Mathf.Lerp(currentRot, 0, smoothing * Time.deltaTime);
        if (!isRotating)
        {
            transform.localRotation = Quaternion.Euler(xRot, 0f, currentRot);
            body.Rotate(new Vector3(0, 1, 0) * rotX);
        }
    }
    void CameraLean()
    {
        if (Input.GetKey(KeyCode.E) )
        {
            zRot = Mathf.Lerp(zRot, -20, 3 * Time.deltaTime);
            isRotating = true;
            playerScript.canMove = false;
        
        }
        if (Input.GetKey(KeyCode.Q))
            {
            zRot = Mathf.Lerp(zRot, 20, 3 * Time.deltaTime);
            isRotating = true;
            playerScript.canMove = false;
          
        }
        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Q))
        {
            isRotating = false;
            playerScript.canMove = true;
        }
        if (!isRotating)
        {
            zRot = Mathf.Lerp(zRot, 0, 3 * Time.deltaTime);
        }
        leaner.localRotation = Quaternion.Euler(0, 0, zRot);
    }
}
