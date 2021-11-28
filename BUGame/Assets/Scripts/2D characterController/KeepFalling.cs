using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepFalling : MonoBehaviour
{
    [SerializeField] public GameObject respawnposi;
    [SerializeField] public GameObject transition;
    bool done=false;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)&& !done)
        {
            GetComponent<Collider2D>().enabled = false;
            transition.SetActive(true);
            done=true;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.transform.position = respawnposi.transform.position;
        Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity= new Vector2(0f,-1f);
    }
}
