using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private bool Des = false;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyDown("e") && Des == true)
        {
            
        }
    }

    private void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Chest")
        {
            Des = true;
        }
    }
}
