using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject btD;
    [SerializeField] GameObject gun;
    bool temp;
    void OnTriggerEnter2D(Collider2D col)
    {
        player.GetComponent<GunMovementToggle>().enabled =false;
        player.GetComponent<SideScrollerGun>().enabled =false;
        player.GetComponent<CharacterController>().enabled = true;
        gun.SetActive(true);

        this.gameObject.SetActive(false);
        btD.GetComponent<SwitchToApp>().StartCoroutine("effect");

    }
}
