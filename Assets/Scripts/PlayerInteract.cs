using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private bool CanInteract = false;

    GameObject ObjectColliding;
    GameObject Tree;


    IEnumerator MyMethod()
    {
        Debug.Log("Before Waiting for 2 seconds");
        yield return new WaitForSeconds(2);
        Debug.Log("After waiting for 2 seconds");
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && ObjectColliding != null)
        {
            Destroy(ObjectColliding);
        }

        if (Input.GetMouseButtonDown(0) && CanInteract != false)
        {
            StartCoroutine("MyMethod");
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine("MyMethod");
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Chest")
        {
            ObjectColliding = col.gameObject;
            Debug.Log(ObjectColliding);
        }

        if (col.gameObject.tag == "Tree")
        {
            Tree = col.gameObject;
            Debug.Log(ObjectColliding);
            CanInteract = true;
        }

        if (col.gameObject.tag == "Item")
        {
            if(this.gameObject.GetComponent<PlayerController>().PlayerData.Inventory.AddInvItem(col.gameObject.GetComponent<Item_Data>().ItemData))
            {
                Destroy(col.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ObjectColliding = null;
        CanInteract = false;
        StopCoroutine("MyMethod");
    }
}
