using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleScript : MonoBehaviour
{
    public int FileCount=0;
    void OnTriggerEnter2D(Collider2D col)
    {
            switch(col.gameObject.name)
            {
                case "Dragobj1": col.gameObject.SetActive(false);
                                 FileCount++;
                                 break;
                case "Dragobj2": col.gameObject.SetActive(false);
                                 FileCount++;
                                 break;
            }
    }
}
