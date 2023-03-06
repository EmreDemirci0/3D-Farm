using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutScene : MonoBehaviour
{
    Camera mainCam;
    [SerializeField] GameObject cutsceneCam;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject bosImage, bosImage2, bosImage3;//ciddili boþ
    [SerializeField] KeyController keyController;
    [SerializeField] GameObject openDoorPanel;
    [SerializeField] List<CutSceneClass> cutSceneClasses;

    private void Awake()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }
    private void Start()
    {
        bosImage.SetActive(false);
        bosImage2.SetActive(false);
        bosImage3.SetActive(false);
        for (int i = 0; i < cutSceneClasses.Count; i++)
        {
            cutSceneClasses[i].mainKey.SetActive(false);
            cutSceneClasses[i].AfterNote.SetActive(false);
        }

    }

    public IEnumerator startAnimCutScene(int index, float animSec, string itemTag,bool on)
    {
        Player.gameObject.SetActive(false);//-33.014 3.1 -0.218
        openDoorPanel.SetActive(false);
        mainCam.enabled = false;
        cutSceneClasses[index].mainKey.SetActive(true);
        cutSceneClasses[index].thisObject.GetComponent<BoxCollider>().enabled = (true);
        
        cutsceneCam.gameObject.SetActive(true);
        cutsceneCam.transform.localPosition = cutSceneClasses[index].CamTransform;
        cutsceneCam.transform.rotation = Quaternion.Euler(cutSceneClasses[index].CamRotation);
        cutSceneClasses[index].anim.Play();
        yield return new WaitForSeconds(animSec);
        cutSceneClasses[index].AfterNote.SetActive(true);//kilit açaýlýnca 3.not açýlýyor.
        mainCam.enabled = true;
        cutSceneClasses[index].lockKey.gameObject.AddComponent<Rigidbody>();
        cutSceneClasses[index].lockKey.gameObject.transform.position -= new Vector3(.1f, 0, 0);
        cutSceneClasses[index].thisObject.GetComponent<BoxCollider>().enabled = false;
        Player.gameObject.SetActive(true);
        cutsceneCam.gameObject.SetActive(false);
        cutSceneClasses[index].mainKey.SetActive(on);
        cutSceneClasses[index].cekmece.gameObject.tag = itemTag;
        bosImage.SetActive(true); bosImage2.SetActive(true);bosImage3.SetActive(true);


    }
    //public IEnumerator deneme()
    //{
    //    //sýkýntýlar var hallet
    //    for (int i = 0; i < cutSceneClasses.Count; i++)
    //    {

    //            print("i:" + i);
    //            mainCam.enabled = false;
    //            cutSceneClasses[i].mainKey.SetActive(true);
    //            cutSceneClasses[i].thisObject.GetComponent<BoxCollider>().enabled = (true);
    //            Player.gameObject.SetActive(false);//-33.014 3.1 -0.218
    //            cutsceneCam.gameObject.SetActive(true);

    //            cutsceneCam.transform.localPosition = cutSceneClasses[i].CamTransform;
    //            cutsceneCam.transform.rotation = Quaternion.Euler(cutSceneClasses[i].CamRotation);
    //            cutSceneClasses[i].anim.Play();
    //            yield return new WaitForSeconds(3);
    //            cutSceneClasses[i].AfterNote.SetActive(true);//kilit açaýlýnca 3.not açýlýyor.

    //            mainCam.enabled = true;
    //            cutSceneClasses[i].lockKey.gameObject.AddComponent<Rigidbody>();
    //            cutSceneClasses[i].lockKey.gameObject.transform.position -= new Vector3(.1f, 0, 0);
    //            cutSceneClasses[i].lockKey.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    //            cutSceneClasses[i].thisObject.GetComponent<BoxCollider>().enabled = false;
    //            Player.gameObject.SetActive(true);
    //            cutsceneCam.gameObject.SetActive(false);
    //            cutSceneClasses[i].mainKey.SetActive(false);
    //            //cutSceneClasses[i].cekmece.gameObject.tag = "Drawer";
    //            bosImage.SetActive(true); bosImage2.SetActive(true);
    //            bosImage3.SetActive(true);


    //    }


    //}

    //public IEnumerator startDrawerAnim(string a)
    //{
    //    //sýkýntýlar var hallet
    //    for (int i = 0; i < 1; i++)
    //    {

    //        mainCam.enabled = false;
    //        cutSceneClasses[i].mainKey.SetActive(true);
    //        cutSceneClasses[i].thisObject.GetComponent<BoxCollider>().enabled = (true);
    //        Player.gameObject.SetActive(false);//-33.014 3.1 -0.218
    //        cutsceneCam.gameObject.SetActive(true);

    //        cutsceneCam.transform.localPosition = cutSceneClasses[i].CamTransform;
    //        cutsceneCam.transform.rotation = Quaternion.Euler(cutSceneClasses[i].CamRotation);
    //        cutSceneClasses[i].anim.Play();
    //        yield return new WaitForSeconds(3);
    //        cutSceneClasses[i].AfterNote.SetActive(true);//kilit açaýlýnca 3.not açýlýyor.

    //        mainCam.enabled = true;
    //        cutSceneClasses[i].lockKey.gameObject.AddComponent<Rigidbody>();
    //        cutSceneClasses[i].lockKey.gameObject.transform.position -= new Vector3(.1f, 0, 0);
    //        cutSceneClasses[i].lockKey.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    //        cutSceneClasses[i].thisObject.GetComponent<BoxCollider>().enabled = false;
    //        Player.gameObject.SetActive(true);
    //        cutsceneCam.gameObject.SetActive(false);
    //        cutSceneClasses[i].mainKey.SetActive(false);
    //        //cutSceneClasses[i].cekmece.gameObject.tag = "Drawer";
    //        bosImage.SetActive(true); bosImage2.SetActive(true);
    //        bosImage3.SetActive(true);

    //    }
    //}
}
[System.Serializable]
public class CutSceneClass
{
    [SerializeField] internal Animation anim;//
    [SerializeField] internal GameObject mainKey;//
    [SerializeField] internal GameObject lockKey;//
    [SerializeField] internal GameObject cekmece;//
    [SerializeField] internal GameObject AfterNote;//0.2911794 0.6214429 -0.4025593
    [SerializeField] internal GameObject thisObject;

    [Tooltip("Kamerayý gereken yere koyup elle giriyoruz")]
    [SerializeField] internal Vector3 CamTransform;//
    [SerializeField] internal Vector3 CamRotation;//
    
}