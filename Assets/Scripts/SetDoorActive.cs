using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SetDoorActive : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Interactable>().enabled = false;
        GetComponent<CircularDrive>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {


        
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            GetComponent<Interactable>().enabled = true;
            GetComponent<CircularDrive>().enabled = true;
        }
    }
}
