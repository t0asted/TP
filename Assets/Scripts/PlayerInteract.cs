using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInteract : MonoBehaviour {

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if (Input.GetKeyDown ("E"))
        {
            Destroy(GameObject.FindWithTag("Chest"));
        }
	}
}
