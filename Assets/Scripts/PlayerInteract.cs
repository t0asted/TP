using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private bool Des = false;

    GameObject ObjectColliding;
	
	void Update ()
    {
        if(Input.GetKeyDown("e") && ObjectColliding != null)
        {
            Destroy(ObjectColliding);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Chest")
        {
            ObjectColliding = col.gameObject;
            Debug.Log(ObjectColliding);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ObjectColliding = null;
    }
}
