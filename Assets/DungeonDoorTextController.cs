using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDoorTextController : MonoBehaviour
{
    [SerializeField] GameObject openDoorPanel;
    [SerializeField] TMPro.TextMeshProUGUI ForestHomeText, DoorText;
    KeyController keyController;
    private void Start()
    {
        GetComponent<OpenDoorCollider>().enabled = false;
        keyController = GameObject.FindGameObjectWithTag("gameController").GetComponent<KeyController>();
        ForestHomeText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Player")
        {
            print("girdi");
            if (keyController.isHaveCrystalBall)
            {
                print("emre");
                DoorText.gameObject.SetActive(true);
                ForestHomeText.gameObject.SetActive(false);
                GetComponent<OpenDoorCollider>().enabled = true;
            }
            else
            {
                DoorText.gameObject.SetActive(false);
                ForestHomeText.gameObject.SetActive(true);
                GetComponent<OpenDoorCollider>().enabled = false;
                ForestHomeText.text = "Kristal Kure bulmalisin";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "Player")
        {
            ForestHomeText.gameObject.SetActive(false);

        }
    }
}
