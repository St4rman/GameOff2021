using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace EndDialogueSystem
{
    public class EndDialogueBase : MonoBehaviour
    { 
        
        public bool finished {get; private set;}
        protected IEnumerator WriteText(string input, Text textHolder,Color textColor,Font textFont,AudioClip sound)
        { 
            textHolder.color = textColor;
            textHolder.font = textFont;
            for(int i=0;i<input.Length;i++)
            {
                textHolder.text += input[i];
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            finished = true;
        }
    }
} 
