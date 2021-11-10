using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerPlatformer : MonoBehaviour
{
    [Header("Physics variables")]
    public float moveSpeed; 

    [Header("References")]
    Rigidbody2D pRb;
    Transform pTransform;
    BoxCollider2D mainCollider; 
    

    [Header("Debugging")]
    public float xVelocity;


    void Awake()
    {
        pRb = GetComponent<Rigidbody2D>();
        pRb.freezeRotation = true;
        mainCollider = GetComponent<BoxCollider2D>();

    }

    
    void Update()
    {
        //Getting input from player
        float xInput =  Input.GetAxis("Horizontal");
        float xVelocity = xInput * moveSpeed * 100 * Time.deltaTime;

        pRb.velocity = new Vector2(xVelocity, pRb.velocity.y);
    }
}
