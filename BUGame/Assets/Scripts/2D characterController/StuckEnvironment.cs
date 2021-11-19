using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckEnvironment : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] CharacterControllerPlatformer _ccp;
    [SerializeField] MovementScriptManager _msp;
    public float timer;
    public float m,n;
    public float keyCount;
    //n keypresses in m time
    public bool temp;
    void Update()
    {
        if(temp) timer += Time.deltaTime;

        if((Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.A)||
            Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.S)) 
            && !temp)
        {
            StartCoroutine("checkPress");
        }

        if(timer>0){
            if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.A)||
            Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.S))
            {
                keyCount +=1;
            }
        }

        if(keyCount > n)
        {
            Debug.Log("Escaped");
            passed();
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        _ccp.enabled = false;
    }

    void passed()
    {
        _ccp.enabled = true;
        _msp.enabled = true;
        gameObject.SetActive(false);
    }
    IEnumerator checkPress(){
        timer =0f;
        temp = true;
        yield return new WaitForSeconds(m);
        temp = false;
        keyCount =0;
    }
}
