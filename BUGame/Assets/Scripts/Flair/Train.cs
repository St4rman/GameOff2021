using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Train : MonoBehaviour
{
    [SerializeField] GameObject train;
    [SerializeField] private float cycleLen;
    [SerializeField] private float yval;
    
    void Start()
    {
        transform.DOMove(new Vector3(transform.position.x,transform.position.y + yval,transform.position.z), cycleLen).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
