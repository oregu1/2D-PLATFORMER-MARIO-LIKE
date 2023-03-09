using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 7.0f;
    public float jumpForce = 7.0f;
    private bool doubleJump;

    Vector2 movement;

    //REFERENCES
    private Rigidbody2D playerRB;
    private Animator playerAnimator;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask groundLayer;

    private enum AnimationState
    {
        idle, //0
        run, //1
        fall, //2
        jump, //3
        dblJump, //4
        hit //5
    }


    public void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        MoveCharacter();
        UpdateAnimationState();
    }

    private void MoveCharacter()
    {
        playerRB.velocity = new Vector2(movement.x * playerSpeed, playerRB.velocity.y);
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(IsGrounded())
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                doubleJump = true;
            }
            else if (doubleJump)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                doubleJump = false;
            }

        } 
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }

    private void UpdateAnimationState()
    {
        AnimationState state;
        if(movement == Vector2.zero)
        {
            state = AnimationState.idle;
        }
        else if(movement.x > .1f)
        {
            state = AnimationState.run;
            transform.localScale = new Vector2(0.8f, 0.8f);
        }
        else
        {
            state = AnimationState.run;
            transform.localScale = new Vector2(-0.8f, 0.8f);
        } 
        

        if (playerRB.velocity.y > .1f)
        {
            state = AnimationState.jump;
        }
        else if (playerRB.velocity.y < -.1f)
        {
            state = AnimationState.fall;
        }

        if(doubleJump)
        {
            state = AnimationState.dblJump;
        }

        playerAnimator.SetInteger("AnimState", (int)state);
    }
}
