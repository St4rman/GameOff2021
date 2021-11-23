using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject player;
    bool temp;
    void OnTriggerEnter2D(Collider2D col)
    {
        player.GetComponent<GunMovementToggle>().enabled =false;
        player.GetComponent<SideScrollerGun>().enabled =false;

        temp = player.GetComponent<CharacterController>().enabled;
        player.GetComponent<CharacterController>().enabled = !temp;

        this.gameObject.SetActive(false);
    }
}
