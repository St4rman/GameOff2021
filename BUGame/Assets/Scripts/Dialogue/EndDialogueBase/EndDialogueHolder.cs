using UnityEngine;
using System.Collections;
namespace EndDialogueSystem
{
    public class EndDialogueHolder : MonoBehaviour
    {
        [SerializeField] GlobalManager gm;
        bool DialogueStart=true;
        public int levelnumber=0;
        public bool levelend=false;
        public bool final=false;
        /*private void Awake()
        {
            StartCoroutine(dialogueSequence(ln));
        }*/
        void Update()
        {
              if(DialogueStart&&gm.fullComplete)
              {
                  DialogueStart=false;
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
                yield return new WaitUntil(()=>transform.GetChild(levelnumber).GetChild(i).GetComponent<EndDialogueLine>().finished);
            }
            transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
            final=true;
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
