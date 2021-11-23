using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepFalling : MonoBehaviour
{
    [SerializeField] public GameObject respawnposi;
    [SerializeField] public GameObject transition;
    public bool done=false;

    void Update(){
        if(done)
        {
            GetComponent<Collider2D>().enabled = false;
            transition.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.transform.position = respawnposi.transform.position;
        Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity= new Vector3(0f,-1f,0f);
    }
}
