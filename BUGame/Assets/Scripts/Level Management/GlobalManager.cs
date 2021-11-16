using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public bool allowInteract = false;
    public GameObject[] interactables;
    void Update()
    {
        StartCoroutine(setInteract());
    }

    IEnumerator setInteract()
    {
        for (int i =0; i< interactables.Length; i++)
        {
            interactables[i].GetComponent<SwitchToApp>().appWorking = allowInteract;
        }
        yield return null;
    }

}
