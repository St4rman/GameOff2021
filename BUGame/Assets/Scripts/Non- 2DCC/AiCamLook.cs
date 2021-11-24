using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AiCamLook : MonoBehaviour
{

    [Header("Sutveillance Rotation")]
    public float surveillanceAngle;

    private float startAngle;


    void Awake()
    {
        startAngle = transform.localEulerAngles.z;
    }
    void Update()
    {
        surveillance();
    }

    void surveillance(){
        float angle = Mathf.Sin(Time.time)* surveillanceAngle + startAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
