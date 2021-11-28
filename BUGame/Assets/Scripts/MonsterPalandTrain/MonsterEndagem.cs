using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEndagem : MonoBehaviour
{
    [SerializeField] GlobalManager gm;

    void Awake()
    {
        gm.petCareComplete = true;
    }
}
