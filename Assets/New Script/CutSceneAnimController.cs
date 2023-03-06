using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneAnimController : MonoBehaviour
{
    CutScene cutScene;
    KeyController keyController;

    void Start()
    {
        cutScene = transform.parent.GetComponent<CutScene>();
        keyController = GameObject.FindGameObjectWithTag("gameController").GetComponent<KeyController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (this.gameObject.tag == "drawerAnimCollider" && keyController.isHaveAllKeys)
            {
                StartCoroutine(cutScene.startAnimCutScene(0, 3, "Drawer",false));
            }
            if (this.gameObject.tag == "forestAnimCollider" && keyController.isHaveBlackKey)
            {
                StartCoroutine(cutScene.startAnimCutScene(1, 2.5f, "Untagged",false));
            }
            if (this.gameObject.tag == "dungeonAnimCollider" && keyController.isHaveCrystalBall)
            {
                StartCoroutine(cutScene.startAnimCutScene(2, 2.5f, "Untagged",transform));

            }

        }
    }
}
