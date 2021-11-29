using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TimeDialogueSystem
{
    public class TimeDialogueLine : TimeDialogueBase
    {
        private Text textHolder;
        [Header ("Text Options")]
        [SerializeField]private string input;
        [SerializeField]private Color textColor;
        [SerializeField]private Font textFont;

        [Header ("Sound")]
        [SerializeField] private AudioClip sound;
        private void Awake()
        {
            textHolder= GetComponent<Text>();
            textHolder.text="";
            
        }
        private void Start()
        {
            StartCoroutine(TimeWriteText(input,textHolder,textColor,textFont,sound));
        }
    }
}
