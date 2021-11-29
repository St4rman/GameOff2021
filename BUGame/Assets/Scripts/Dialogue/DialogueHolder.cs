using UnityEngine;
using System.Collections;
namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        [SerializeField] GlobalManager gm;
        public int levelnumber=0;
        public bool Introdone=false;
        public bool levelend=false;
        /*private void Awake()
        {
            StartCoroutine(dialogueSequence(ln));
        }*/
        void Update()
        {
              if(Input.GetKeyDown(KeyCode.F)&&levelend)
              {
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
                yield return new WaitUntil(()=>transform.GetChild(levelnumber).GetChild(i).GetComponent<DialogueLine>().finished);
            }
            gm.allowInteract=true;
            Introdone=true;
            transform.gameObject.SetActive(false);
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
