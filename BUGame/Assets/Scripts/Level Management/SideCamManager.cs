using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SideCamManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject playArea;
    [SerializeField] GameObject player;
    public float offsetx, offsety;

    private void OnTriggerEnter2D(Collider2D col )
    {
        
        
        playArea.GetComponent<SwitchToApp>().x += offsetx;
        playArea.GetComponent<SwitchToApp>().y += offsety;
        playArea.GetComponent<SwitchToApp>().OnMouseDown();

        player.transform.position+= new Vector3(3.0f, 0f,0f);
    }
    
}
