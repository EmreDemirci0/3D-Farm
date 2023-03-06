using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotCutScene : MonoBehaviour
{
    Camera mainCam;
    [SerializeField] GameObject cutsceneCam;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject openDoorPanel;
    [SerializeField] GameObject purplePotion, greenPotion, Wand, CrystalBall;
    Animation purplePotionAnimation, greenPotionAnimation, wandAnimation;

    [Tooltip("Kamerayý gereken yere koyup elle giriyoruz")]
    [SerializeField]Vector3 CamTransform;//
    [SerializeField]Vector3 CamRotation;//

    KeyController keyController;
    [SerializeField] ParticleSystem PotParticleSystem;
    float startSize = 0f;
    bool isAnimFinish,isAnimationStart;
    bool isInsidePotCutScene;
    [SerializeField] GameObject burnThePotText;
    [SerializeField] Material skyboxMaterial;
    Light DirectionLight;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        DirectionLight = GameObject.FindGameObjectWithTag("Light").GetComponent<Light>();
        purplePotionAnimation = purplePotion.GetComponent<Animation>();
        greenPotionAnimation = greenPotion.GetComponent<Animation>();
        wandAnimation= Wand.GetComponent<Animation>();
        purplePotionAnimation = purplePotion.GetComponent<Animation>();
        keyController = GameObject.FindGameObjectWithTag("gameController").GetComponent<KeyController>();
        purplePotion.gameObject.SetActive(false);
        Wand.gameObject.SetActive(false);
        greenPotion.gameObject.SetActive(false);
        CrystalBall.gameObject.SetActive(false);
        burnThePotText.gameObject.SetActive(false);
        PotParticleSystem.Play();
    }
    private void Update()
    {
        if (isInsidePotCutScene)
        {
            if (keyController.isHavePotItems)
            {
                if (Input.GetKeyDown(KeyCode.P) && !isAnimFinish)
                {
                    print("pye bastý");
                    isAnimationStart = true;
                    burnThePotText.gameObject.SetActive(false);
                    StartCoroutine(startAnimCutScene(3));
                    RenderSettings.skybox = skyboxMaterial;
                    DirectionLight.enabled=(false);
                }
            }
          
           
        }
    }
    private void OnTriggerStay(Collider other)
    {   
    
            var main = PotParticleSystem.main;
            if (isAnimationStart)
            {
                burnThePotText.gameObject.SetActive(false);
                startSize += Time.deltaTime;
                main.startSize = startSize;
            }
            if(isAnimFinish)
            {
                startSize -= 200*Time.deltaTime;
                main.startSize = startSize;
            }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            if (keyController.isHavePotItems && !isAnimFinish)
            {
                isInsidePotCutScene = true;
                burnThePotText.gameObject.SetActive(true);
            }
           
        }   
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInsidePotCutScene = false;
            burnThePotText.gameObject.SetActive(false);
        }
    }

    public IEnumerator startAnimCutScene(float animSec)
    {
        openDoorPanel.SetActive(false);
        mainCam.enabled = false;
        cutsceneCam.gameObject.SetActive(true);
        cutsceneCam.transform.localPosition = CamTransform;
        cutsceneCam.transform.rotation = Quaternion.Euler(CamRotation);
        Player.gameObject.SetActive(false);//-33.014 3.1 -0.218
        cutsceneCam.gameObject.SetActive(true);

        wandAnimation.Play();
        Wand.gameObject.SetActive(true);
        //yield return new WaitForSeconds(1);

        purplePotionAnimation.Play();
        purplePotion.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        purplePotion.gameObject.AddComponent<Rigidbody>();
        purplePotion.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        yield return new WaitForSeconds(.5f);

        greenPotionAnimation.Play();
        greenPotion.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        greenPotion.gameObject.AddComponent<Rigidbody>();
        greenPotion.gameObject.GetComponent<BoxCollider>().isTrigger = false;

        mainCam.enabled = true;
        Player.gameObject.SetActive(true);
        cutsceneCam.gameObject.SetActive(false);
        yield return new WaitForSeconds(animSec);

        wandAnimation.Stop();
        CrystalBall.SetActive(true);
        //thiss.gameObject.SetActive ( false);
        isAnimFinish = true;
        isAnimationStart = false;
    }
}
