using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastDialogue : MonoBehaviour
{
    [SerializeField] EndDialogueSystem.EndDialogueHolder enddialogue;
    public Text LastLine;
    public bool monologedone = false;
    void Update()
    {
        
        if(enddialogue.final)
        {
            wait();
            LastLine.text="I enjoyed my "+Mathf.RoundToInt(Time.realtimeSinceStartup)+" seconds with you :]";
        }

    }

    private void wait(){
        StartCoroutine("anticipation");
    }

    public IEnumerator anticipation(){
        yield return new WaitForSeconds(5f);
        monologedone = true;
    }
}
