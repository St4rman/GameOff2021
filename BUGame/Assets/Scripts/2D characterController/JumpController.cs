using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("Assignables")]
    [SerializeField] public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce;
    public float downForce;
    [Header("Ground Checker")]
    public bool isGrounded;
    [SerializeField] public Transform jumpChecker;
    public float checkRadius;
    public LayerMask groundLayer;

    [Header("Physics Assign")]
    public Rigidbody2D playerRigidbody;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded  = Physics2D.OverlapCircle(jumpChecker.position, checkRadius, groundLayer);

        if(Input.GetKeyDown(jumpKey)&& isGrounded)
        {
            jump();
        }

        if(playerRigidbody.velocity.y < 0 )
        {
            playerRigidbody.AddForce(-Vector2.up * downForce);
        }
    }

    void jump()
    {
        playerRigidbody.velocity = Vector2.up * jumpForce;
    }
}
