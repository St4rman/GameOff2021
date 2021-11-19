using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepFalling : MonoBehaviour
{
    [SerializeField] public GameObject respawnposi;
    public bool done=false;
    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.transform.position = respawnposi.transform.position;
        Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity= new Vector3(0f,0f,0f);
    }
}
