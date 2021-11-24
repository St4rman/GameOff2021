using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SwitchToApp : MonoBehaviour
{
    [SerializeField] Camera camref;
    [SerializeField] float time;
    [SerializeField] GameObject playAreaTo;
    [SerializeField] GameObject playAreaFrom;
    public float x;
    public float y;
    public bool appWorking;

    public bool appCleaned;

    public void OnMouseDown()
    {
        StartCoroutine(effect(x,y));

    }

    public IEnumerator effect(float dx, float dy)
    {
        
        if(appWorking && !appCleaned)
        {
            camref.transform.DOMove(new Vector3(dx, dy, -10f), time, false);

            playAreaTo.SetActive(true);
            playAreaFrom.SetActive(false);
        }
        
        yield return null;
    }
}
