using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] List<SCMyItem> item;
    [SerializeField] SCMyInventory MyUserInventory;
    Animator CollectedTextAnimator;
    MyInventoryUIController myInventoryUIController;
    KeyController keyController;
    private void Start()
    {
        CollectedTextAnimator = GameObject.FindGameObjectWithTag("itemCollectedText").GetComponent<Animator>();
        myInventoryUIController = GameObject.FindGameObjectWithTag("gameController").GetComponent<MyInventoryUIController>();
        keyController = GameObject.FindGameObjectWithTag("gameController").GetComponent<KeyController>();
       
    }
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Item" )
            for (int i = 0; i < item.Count; i++)
                CollisionCompare(collision, i);
    }
    
    void CollisionCompare(Collider collision,int itemIndex)
    {
        if (collision.gameObject.name == item[itemIndex].name)
        {//itemlere key tegi ver
            MyUserInventory.AddItem(item[itemIndex]);
            myInventoryUIController.UpdatesInventoryUI();
            CollectedTextAnimator.SetBool("isCollected", true);
            Destroy(collision.gameObject);
            StartCoroutine(TextCoolDown());
            keyController.UpdateHaveKey();
        }
    }
    IEnumerator TextCoolDown()
    {
        yield return new WaitForSeconds(1f);
        CollectedTextAnimator.SetBool("isCollected", false);
    }
}
