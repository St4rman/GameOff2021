using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace DialogueSystem
{
    public class DialogueBase : MonoBehaviour
    { 
        
        public bool finished {get; private set;}
        protected IEnumerator WriteText(string input, Text textHolder,Color textColor,Font textFont)
        { 
            textHolder.color = textColor;
            textHolder.font = textFont;
            for(int i=0;i<input.Length;i++)
            {
                textHolder.text += input[i];
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            finished = true;
        }
    }
} 
