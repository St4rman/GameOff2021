using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastDialogue : MonoBehaviour
{
    [SerializeField] EndDialogueSystem.EndDialogueHolder enddialogue;
    public Text LastLine;
    void Update()
    {
        
        if(enddialogue.final)
        {
            
            LastLine.text="I enjoyed my "+Mathf.RoundToInt(Time.realtimeSinceStartup)+" seconds with you :]";
        }

    }
}
