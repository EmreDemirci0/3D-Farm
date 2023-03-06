using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeRotate : MonoBehaviour
{
    [SerializeField] private Vector3 startPos, EndPos;
    [SerializeField] private float duration;
    [SerializeField] private GameObject RotatingObject;
    // Start is called before the first frame update
    void Start()
    {
        Move();

    }
    void Update()
    {
        RotatingObject.transform.Rotate(new Vector3(0, 0, 10));
    }
    void Move()
    {
        RotatingObject.transform.DOLocalMove(startPos, duration).OnComplete(() => {
        RotatingObject.transform.DOLocalMove(EndPos, duration).OnComplete(Move);
            });
    }
}

