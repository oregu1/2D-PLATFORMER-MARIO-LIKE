using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 7.0f;

    float movement = 0;

    //REFERENCES
    private Rigidbody2D playerRB;
    private Animator playerAnimator;

    private enum AnimationState
    {
        idle,
        run,
        fall,
        jump,
        dblJump,
        hit
    }

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement = Input.GetAxisRaw("Horizontal");

        playerRB.velocity = new Vector2(movement * playerSpeed, playerRB.velocity.y);
    }
}
