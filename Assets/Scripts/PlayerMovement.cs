using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;


    private bool isFacingRight = true;

    Animator anim;
    private Rigidbody2D body;
    private float moveHorizontalInput;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveHorizontalInput = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private void FixedUpdate()
    {
        body.linearVelocityX = moveHorizontalInput * moveSpeed;
        anim.SetFloat("xVelocity",Math.Abs(body.linearVelocityX));
        anim.SetFloat("yVelocity", body.linearVelocityY);
    }
  
    private void Flip()
    {


        if (isFacingRight && moveHorizontalInput < 0f || !isFacingRight && moveHorizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


}
