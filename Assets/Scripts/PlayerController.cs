using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PlayerData
    public PlayerData PlayerData;

    Rigidbody2D myRB;
    bool FacingRight = true;
    SpriteRenderer SpriteRender;
    Animator myAnim;

    //move
    public float maxSpeed;

    //jump
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpPower;

    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        SpriteRender = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            myAnim.SetBool("IsGrounded", false);
            myRB.velocity = new Vector2(myRB.velocity.x, 0f);
            myRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            grounded = false;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("IsGrounded", grounded);

        float move = Input.GetAxis("Horizontal");

        if (move > 0 && !FacingRight)
            Flip();

        else if (move < 0 && FacingRight)
            Flip();

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        myAnim.SetFloat("MoveSpeed", Mathf.Abs(move));

    }

    void Flip()
    {
        FacingRight = !FacingRight;
        SpriteRender.flipX = !SpriteRender.flipX;
    }

}
