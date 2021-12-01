using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public bool allowInteract;
    public GameObject[] interactables;

    public bool petCareComplete, platformerComplete, trainComplete, cleanerComplete;

    public bool fullComplete;

    void Update()
    {
        if(allowInteract && !fullComplete){
            StartCoroutine(setInteract(true));
        }

        if(petCareComplete & platformerComplete & trainComplete & cleanerComplete)
        {
            fullComplete = true;
            
        }

        if(fullComplete){
            StartCoroutine (setInteract(false));
            StartCoroutine (setLastBoss());
        }
    }

    IEnumerator setInteract(bool temp)
    {
        for (int i =0; i< interactables.Length; i++)
        {
            interactables[i].GetComponent<SwitchToApp>().appWorking = temp;
        }
        yield return null;
    }

    IEnumerator setLastBoss()
    {
        yield return null;
    }

}
