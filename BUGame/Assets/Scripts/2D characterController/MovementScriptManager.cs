using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptManager : MonoBehaviour
{
    //this basically makes sure that the right scripts work at the right times
    //you dont want the gunrecoil movement and wasd movement working at the same time
    public SideScrollerGun _ssg;
    public CharacterControllerPlatformer _ccp;

    [Header("Debug")]
    public bool s;
    public bool c;
    void Update()
    {
        //Debug
        s = _ssg.enabled;
        c = _ccp.enabled;

        //doing it based off a key rn ingame u can toggle it when player got gun
        if(Input.GetKeyDown(KeyCode.E))
        {
            ToggleGunScript();
        }

        if(_ssg.enabled)
        {
            _ccp.enabled=false;
        } else {
            _ccp.enabled = true;
        }
    }

    void ToggleGunScript()
    {
        bool temp = _ssg.enabled;
        _ssg.enabled = !temp;
        Debug.Log("bruh");

    }
}
