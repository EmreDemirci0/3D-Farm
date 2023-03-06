using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(BoxCollider))]
public class OpenDoorCollider : MonoBehaviour
{
    [SerializeField]private DoorAnimController doorAnimController;
    private bool isPlayerInside;
    [SerializeField] private GameObject OpenDoorPanel;
    [SerializeField] TMPro.TextMeshProUGUI openDoorText;

    private void Awake()
    {
        doorAnimController = GetComponent<DoorAnimController>();
    }
    private void Start()
    {
        isPlayerInside = false;
        OpenDoorPanel.SetActive(false);
    }
    private void Update()
    {
        if (isPlayerInside)
        {
            OpenDoorPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T))
                doorAnimController.PlayAnimation();
        }
        
    }
    private void OnTriggerStay(Collider other)
    {   
        if (other.gameObject.tag == "Player")
        {
            if (OpenDoorPanel.activeSelf==true)
            {
                if (doorAnimController.isDoorOpen)
                    openDoorText.text = "Kapiyi kapatmak icin T'ye Basiniz";
                else
                    openDoorText.text = "Kapiyi acmak icin T'ye Basiniz";
                
            }
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        { 
            isPlayerInside = true;
            OpenDoorPanel.SetActive(true);
            openDoorText.gameObject.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("yunus");
            isPlayerInside = false;
            OpenDoorPanel.SetActive(false);
        }
    }
}
