using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvedConditionPlatformer : MonoBehaviour
{
    
    [SerializeField] GameObject gun;
    [SerializeField] DragItemScript DragItemScript;
    bool isDone = true;

    // Update is called once per frame
    public void Update()
    {
        if (DragItemScript.spawnCondition && isDone)
        {
            gun.SetActive(true);
            isDone=false;
        }
    }
}
