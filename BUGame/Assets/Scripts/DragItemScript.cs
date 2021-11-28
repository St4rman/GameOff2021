using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragItemScript : MonoBehaviour
{
    Collider2D col;
    public GameObject dragObject;
    public bool spawnCondition=false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name==dragObject.name)
        {
            spawnCondition=true;
            col.gameObject.SetActive(false);

        }
    }
}
