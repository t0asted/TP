using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float PlayerSpeed = 10f;
    public float JumpSpeed = 10f;

    private Rigidbody2D rb2d;
	
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Vector2 jump = new Vector2(0,moveVertical);
        rb2d.AddForce(movement * PlayerSpeed);
        rb2d.AddForce(jump * JumpSpeed);
    }
}
