using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualApps : MonoBehaviour
{
    [SerializeField] DragItemScript draggedin;
    [SerializeField] GameObject afterImage;
    [SerializeField] GameObject beforeImage;
    [SerializeField] GameObject endgame;
    bool isDone =true;

    void Update()
    {
        if(draggedin.spawnCondition && isDone)
        {
            beforeImage.SetActive(false);
            afterImage.SetActive(true);
            endgame.SetActive(true);
            isDone =false;
        }
    }
}
