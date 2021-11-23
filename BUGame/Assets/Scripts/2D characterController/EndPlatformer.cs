using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatformer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GlobalManager gm;

    void OnTriggerEnter2D(Collider2D col)
    {
        Player.SetActive(false);
        gm.platformerComplete = true;
    }

}
