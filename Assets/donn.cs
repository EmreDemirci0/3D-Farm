using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class donn : MonoBehaviour
{
    [SerializeField]Vector3 startPos,EndPos;
    [SerializeField]float duration;
    [SerializeField]GameObject rotatingObject;
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(-1.992f,0,4.715f);
        EndPos = new Vector3(-4.277f,0, 4.319f);
        Move();

    }
    void Update()
    {
        rotatingObject.transform.Rotate(new Vector3(0, 0, 10));
    }
    void Move()
    {
        transform.DOLocalMove(EndPos, duration).OnComplete(() => {
            transform.DOLocalMove(startPos, duration).OnComplete(Move);
        });
    }


}
