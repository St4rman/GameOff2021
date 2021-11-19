using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovementToggle : MonoBehaviour
{
    [SerializeField] MovementScriptManager _msp;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            _msp.ToggleGunScript();
            gameObject.SetActive(false);
        }
    }
}
