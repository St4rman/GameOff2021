using UnityEngine;
using System.Collections;
namespace TimeDialogueSystem
{
    public class TimeDialogueHolder : MonoBehaviour
    {
        [SerializeField]  DialogueSystem.DialogueHolder IntroDiag;
        [SerializeField] GlobalManager gm;
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
              if(gm.fullComplete)
              {
                  transform.gameObject.SetActive(false);
              }
        }
        void StartSequence()
        {
            StartCoroutine(dialogueSequence());
        }
        
       private IEnumerator dialogueSequence()
        {
            transform.GetChild(levelnumber).gameObject.SetActive(true);
            
            for(int i=0;i<(transform.GetChild(levelnumber).childCount)*2;i++)
            {
                int x=Random.Range(0,transform.GetChild(levelnumber).childCount);
                Deactivate(levelnumber);
                transform.GetChild(levelnumber).GetChild(x).gameObject.SetActive(true);
                yield return new WaitUntil(()=>transform.GetChild(levelnumber).GetChild(x).GetComponent<TimeDialogueLine>().finished);
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
