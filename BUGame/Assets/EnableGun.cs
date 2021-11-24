using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGun : MonoBehaviour
{
    [SerializeField] GameObject gun;
    bool gunActive;
    void SetGunEnabled()
    {
        gun.SetActive(gunActive);
    }
}
