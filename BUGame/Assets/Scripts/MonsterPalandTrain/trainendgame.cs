using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainendgame : MonoBehaviour
{
    [SerializeField] GlobalManager gm;

    void Awake()
    {
        gm.trainComplete = true;
    }
}

