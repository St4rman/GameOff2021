using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class background : MonoBehaviour
{
    public float looptime = 4f;
    private Vector3 startPosi;
    private Vector3 endPosi;
    [SerializeField] GameObject backdrop;
    void Start()
    {
        startPosi = transform.position;
        endPosi.x = startPosi.x-17;
        endPosi.y = 0;
        endPosi.z = startPosi.z;
    }

    // Update is called once per frame
    void Update()
    {
        backdrop.transform.Translate(endPosi* looptime * Time.deltaTime);
        
        if (backdrop.transform.position.x< -17f)
        {
            backdrop.transform.position = startPosi;
        }
    }
}
