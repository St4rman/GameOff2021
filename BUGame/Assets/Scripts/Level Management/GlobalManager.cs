using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public bool allowInteract = false;
    public GameObject[] interactables;

    public bool petCareComplete, platformerComplete, trainComplete, cleanerComplete;

    public bool fullComplete;
    public bool bossBeaten;

    void Update()
    {
        StartCoroutine(setInteract());

        if(petCareComplete & platformerComplete & trainComplete & cleanerComplete)
        {
            fullComplete = true;
            StartCoroutine(setEndgame());
        }
    }

    IEnumerator setInteract()
    {
        for (int i =0; i< interactables.Length; i++)
        {
            interactables[i].GetComponent<SwitchToApp>().appWorking = true;
        }
        yield return null;
    }

    public void complete(int i)
    {
        interactables[i].GetComponent<SwitchToApp>().appWorking = false;
    }

    IEnumerator setEndgame()
    {
        // for (int i=0; i< interactables.Length; i++)
        // {
        //     interactables[i].GetComponent<SwitchToApp>().appWorking = false;
        // }
        yield return null;
    }
}
