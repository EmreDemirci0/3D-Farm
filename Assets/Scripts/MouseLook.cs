using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(20, 500)] [SerializeField] private float sens;
    [SerializeField] Transform body;

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
        Cursor.visible = false;
       Cursor.lockState = CursorLockMode.Locked;
       
    }
    private void Update()
    {   
        //bu if market panelini açınca ekranın dönmemesi için
        if (Cursor.visible==false && Cursor.lockState==CursorLockMode.Locked)
        {
            CameraMovement();
            CameraLean();
        }
        
    


    }
    private void CameraMovement()
    {
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;

        xRot -= rotY;   //Burada xRot en ba�ta 0 fareyi yukar� kayd�r�nca yani rotY yi hareket ettirince

        xRot = Mathf.Clamp(xRot, -80f, 80f);

        currentRot += rotX;

        currentRot = Mathf.Lerp(currentRot, 0, smoothing * Time.deltaTime);
        if (!isRotating)
        {
            transform.localRotation = Quaternion.Euler(xRot, 0f, currentRot);// xRota ata ve bunu Kameran�n�n rotasyonuna ata
            //Vector3 vec = new Vector3(0, 1, 0);//vector3.up ile ayn� mant�k
            body.Rotate(new Vector3(0, 1, 0) * rotX);
        }
    }
    void CameraLean()
    {
        if (Input.GetKey(KeyCode.E) /*&& !playerScript.isLeaning*/)
        {
            zRot = Mathf.Lerp(zRot, -20, 3 * Time.deltaTime);
            isRotating = true;
            playerScript.canMove = false;
            //playerScript.isLeaning = true;
        }
        if (Input.GetKey(KeyCode.Q)/* && !playerScript.isLeaning*/)
        {
            zRot = Mathf.Lerp(zRot, 20, 3 * Time.deltaTime);
            isRotating = true;
              playerScript.canMove = false;
            //playerScript.isLeaning = true;
        }
        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Q))
        {

            isRotating = false;
               playerScript.canMove = true;
               //playerScript.isLeaning = false;


        }
        if (!isRotating)
        {
            zRot = Mathf.Lerp(zRot, 0, 3 * Time.deltaTime);
        }
        leaner.localRotation = Quaternion.Euler(0, 0, zRot);
    }
}
