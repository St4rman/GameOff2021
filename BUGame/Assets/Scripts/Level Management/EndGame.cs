using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] GlobalManager gm;
    [SerializeField] LastDialogue ld;
    [SerializeField] GameObject button;
    [SerializeField] SceneChange SceneChange;
    bool isactive;
    void Update()
    {
        if(gm.fullComplete && ld.monologedone)
        {
            button.SetActive(true);
            isactive= true;

        }
    }
    public void OnMouseDown(){
        if(ld.monologedone){
            //scenechnage
            SceneChange.EndGame();
        }
    }
}
