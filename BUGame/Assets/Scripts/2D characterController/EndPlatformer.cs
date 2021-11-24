using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndPlatformer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GlobalManager gm;
    [SerializeField] GameObject PlatformerArea;
    [SerializeField] SwitchToApp app;
    [SerializeField] public Camera camref;

    void OnTriggerEnter2D(Collider2D col)
    {
        Player.SetActive(false);
        
        gm.platformerComplete = true;
        app.appCleaned = true;

        StartCoroutine(effect(0f,0f));
    }

    public IEnumerator effect(float dx, float dy)
    {
        camref.transform.DOMove(new Vector3(dx, dy, camref.transform.position.z), 0.5f, false);
        PlatformerArea.SetActive(false);
        yield return null;
    }

}
