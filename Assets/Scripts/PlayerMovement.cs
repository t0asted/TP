using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float PlayerSpeed= 10f;

    private Rigidbody2D rb2d;
	
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizaontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * PlayerSpeed);
    }
}
