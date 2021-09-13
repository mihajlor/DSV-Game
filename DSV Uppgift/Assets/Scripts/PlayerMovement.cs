using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public GameObject groundCheck;
    private bool isGrounded;

    public float movementSpeed = 2f;
    private float defaultMovementSpeed;

    private bool isMoving;
    private float moveDirection = 0f;
    private bool isJumpPressed = false;
    public float jumpForce = 10f;

    private bool isFacingLeft = false;

    private Vector3 velocity;
    public float smoothTime = 0.2f;

    [SerializeField] private LayerMask whatIsGround;

    // Start is called before the first frame update
    public void Start()
    {
        defaultMovementSpeed = movementSpeed;
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Mathf.Abs(moveDirection) > 0.05)
        {
            isMoving = true;
        } else {
            isMoving = false;
        } 



        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            isJumpPressed = true;
            animator.SetTrigger("DoJump");
        }

        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
    }

    private void FixedUpdate()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f, whatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
        }

        Vector3 calculatedMovement = Vector3.zero;
        float verticalVelocity = 0f;

        if (isGrounded == false)
        {
            verticalVelocity = rigidBody2D.velocity.y;
        }

        calculatedMovement.x = movementSpeed * 100f * moveDirection * Time.fixedDeltaTime;
        calculatedMovement.y = verticalVelocity;
        Move(calculatedMovement, isJumpPressed);
        isJumpPressed = false;
    }
    private void Move(Vector3 moveDirection, bool isJumpPressed)
    {
        rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, moveDirection, ref velocity, smoothTime);

        if (isJumpPressed == true && isGrounded == true)
        {
            rigidBody2D.AddForce(new Vector2(0f, jumpForce * 100f));
        }

        if (moveDirection.x > 0f && isFacingLeft == true)
        {
            FlipSpriteDirection();
        }
        else if (moveDirection.x < 0f && isFacingLeft == false)
        {
            FlipSpriteDirection();
        }
    }

    private void FlipSpriteDirection()
    {
        spriteRenderer.flipX = !isFacingLeft;
        isFacingLeft = !isFacingLeft;
    }

    public bool IsFalling()
    {
        if (rigidBody2D.velocity.y < -1f)
        {
            return true;
        }
        return false;
    }

    public void ResetMovementSpeed()
    {
        movementSpeed = defaultMovementSpeed;
    }

    public void SetNewMovementSpeed(float multiplyBy)
    {
        movementSpeed *= multiplyBy;
    }

}


