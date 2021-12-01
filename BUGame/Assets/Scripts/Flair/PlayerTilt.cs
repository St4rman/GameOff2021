using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerTilt : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] GameObject sprite;
    

    // Update is called once per frame
    void Update()
    {
        if(player.velocity.x<0)
        {
            sprite.transform.DORotate(new Vector3(0,0,9f), 0.01f);
        } else if (player.velocity.x >0){
            sprite.transform.DORotate(new Vector3(0,0,-19f), 0.01f);
        }
    }
}
