using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace TimeDialogueSystem
{
    public class TimeDialogueBase : MonoBehaviour
    { 
        
        public bool finished {get; private set;}
        protected IEnumerator TimeWriteText(string input, Text textHolder,Color textColor,Font textFont,AudioClip sound)
        { 
            textHolder.color = textColor;
            textHolder.font = textFont;
            for(int i=0;i<input.Length;i++)
            {
                textHolder.text += input[i];
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(60f);
            finished = true;
        }
    }
} 
