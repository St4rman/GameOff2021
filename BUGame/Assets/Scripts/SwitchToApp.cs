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

    void OnMouseDown()
    {
        StartCoroutine(effect());

    }

    IEnumerator effect()
    {
        if(appWorking)
        {
            camref.transform.DOMove(new Vector3(x, y, -10f), time, false);

            playAreaTo.SetActive(true);
            playAreaFrom.SetActive(false);
        }
        
        yield return null;
    }
}
