using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteBookController : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] Image crosshair;
    [SerializeField] GameObject player;
    [SerializeField] GameObject DrawerTop;
    [SerializeField]List<NotebookClass> notebookClass = new List<NotebookClass>();
    bool drawerOnlyOnce;
    private void Start()
    {
        for (int i = 0; i < notebookClass.Count; i++)
        {
            for (int j = 0; j < notebookClass[i].items.Count; j++)
            {
                if (notebookClass[i].items[j])
                {
                    notebookClass[i].items[j].SetActive(false);

                }
            }
        }
       
    }
    private void Update()
    {
        for (int i = 0; i < notebookClass.Count; i++)
        {
            if (notebookClass[i].isPaperOpen == false)
            {
                notebookClass[i].PaperRectTransform = notebookClass[i].paperCanvas.transform.GetChild(0).GetComponent<RectTransform>();
                notebookClass[i].paperExPos = notebookClass[i].PaperRectTransform.localPosition;
                notebookClass[i].paperExRot = notebookClass[i].PaperRectTransform.rotation.eulerAngles;
                notebookClass[i].paperExScaleX = notebookClass[i].PaperRectTransform.localScale.x;
                notebookClass[i].paperExScaleY = notebookClass[i].PaperRectTransform.localScale.y;
            }
           
        }
        
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        for (int i = 0; i < notebookClass.Count; i++)
        {
            if (Physics.Raycast(transform.position, fwd, out hit, 3, ~(1 << LayerMask.NameToLayer("Player"))))
            {
                if (hit.collider.gameObject.tag == notebookClass[i].interactiveTag)
                {
                    crosshair.color = Color.green;
                    for (int j = 0; j < notebookClass[i].items.Count; j++)
                    {
                        if (notebookClass[i].items[j])
                        {
                            notebookClass[i].items[j].SetActive(true);
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.K) && notebookClass[i].isPaperOpen == false)
                    {
                        notebookClass[i].paperCanvas.renderMode = RenderMode.ScreenSpaceCamera;
                        notebookClass[i].PaperRectTransform.localPosition = Vector3.zero;
                        notebookClass[i].PaperRectTransform.rotation = Quaternion.Euler(Vector3.zero);
                        notebookClass[i].PaperRectTransform.localScale = new Vector2(15, 15);
                        notebookClass[i].isPaperOpen = true;
                        
                        return;
                    }
                }
                else if (hit.collider.gameObject.name != "Paper" || hit.collider.gameObject == null)
                    if (crosshair.color == Color.green) { 
                        crosshair.color = Color.white;
                    }

            }
            else
                if (crosshair.color == Color.green)
                    crosshair.color = Color.white;

            if (Input.GetKeyDown(KeyCode.K) && notebookClass[i].isPaperOpen == true)
            {
               notebookClass[i].paperCanvas.renderMode = RenderMode.WorldSpace;
               notebookClass[i].PaperRectTransform.localPosition = notebookClass[i].paperExPos;
               notebookClass[i].PaperRectTransform.rotation = Quaternion.Euler(notebookClass[i].paperExRot);
               notebookClass[i].PaperRectTransform.localScale = new Vector2(notebookClass[i].paperExScaleX, notebookClass[i].paperExScaleY);
               notebookClass[i].isPaperOpen = false;
                
                if (notebookClass[i].paperCanvas.transform.parent==DrawerTop.transform&&!drawerOnlyOnce)
                {
                    notebookClass[i].PaperRectTransform.localPosition -= new Vector3(.7f, 0, 0);
                    drawerOnlyOnce = true;
                }
               

            }
        }
        

    }
}
[System.Serializable]
public class NotebookClass
{   
    [SerializeField]internal Canvas paperCanvas;
    [SerializeField] internal string interactiveTag;
    [SerializeField]internal List<GameObject> items;
    internal RectTransform PaperRectTransform;
    internal Vector3 paperExPos, paperExRot;
    internal bool isPaperOpen;
    internal float paperExScaleX, paperExScaleY;
}
