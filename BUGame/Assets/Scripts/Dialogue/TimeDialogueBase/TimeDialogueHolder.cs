using UnityEngine;
using System.Collections;
namespace TimeDialogueSystem
{
    public class TimeDialogueHolder : MonoBehaviour
    {
        [SerializeField]  DialogueSystem.DialogueHolder IntroDiag;
        public int levelnumber=0;
        public bool levelend=false;
        bool IsRunning=true;
        /*private void Awake()
        {
            StartCoroutine(dialogueSequence(ln));
        }*/
        void Update()
        {
              if(IntroDiag.Introdone&&levelend&&IsRunning)
              {
                  IsRunning=false;
                  StartSequence();
              }
        }
        void StartSequence()
        {
            
            StartCoroutine(dialogueSequence());
        }
       private IEnumerator dialogueSequence()
        {
            transform.GetChild(levelnumber).gameObject.SetActive(true);
            for(int i=0;i<transform.GetChild(levelnumber).childCount;i++)
            {
                Deactivate(levelnumber);
                transform.GetChild(levelnumber).GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(()=>transform.GetChild(levelnumber).GetChild(i).GetComponent<TimeDialogueLine>().finished);
            }
            transform.GetChild(0).gameObject.SetActive(false);
        }

        private void Deactivate(int levelnumber)
        {
            for(int i=0;i<transform.GetChild(levelnumber).childCount;i++)
            {
                transform.GetChild(levelnumber).GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
