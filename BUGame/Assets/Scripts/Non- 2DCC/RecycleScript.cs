using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RecycleScript : MonoBehaviour
{
    public bool done=false;
    public int FileCount=0;
    public Camera camref;
    [SerializeField] GameObject camPA;
    [SerializeField] SwitchToApp app;
    [SerializeField] GlobalManager gm;
    void OnTriggerEnter2D(Collider2D col)
    {
            switch(col.gameObject.name)
            {
                case "Dragobj1": col.gameObject.SetActive(false);
                                 FileCount++;
                                 break;
                case "Dragobj2": col.gameObject.SetActive(false);
                                 FileCount++;
                                 break;
            }
            if(FileCount==2)
            {
                done=true;
                app.appCleaned = true;
                gm.cleanerComplete =true;
                StartCoroutine(effect(0f,0f));
            }
    }
    public IEnumerator effect(float dx, float dy)
    {
        camref.transform.DOMove(new Vector3(dx, dy, camref.transform.position.z), 0.5f, false);
        camPA.SetActive(false);
        yield return null;
    }
}
