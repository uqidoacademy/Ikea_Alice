using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	private GameObject primoGrabbato;



	void OnTriggerEnter (Collider oggettoForseGrabbabile) {
		IGrabable tempGrab = oggettoForseGrabbabile.gameObject.GetComponent<IGrabable>();
		if(primoGrabbato == null && tempGrab != null && tempGrab.CanGrab()){
			primoGrabbato = oggettoForseGrabbabile.gameObject;
			oggettoForseGrabbabile.gameObject.GetComponent<Renderer>().material.color = Color.blue;
		}
	}

	void OnTriggerExit (Collider oggettoGrabbabile) {
		if(oggettoGrabbabile.gameObject == primoGrabbato){
			primoGrabbato.GetComponent<Renderer>().material.color = Color.white;
			primoGrabbato = null;
		}
	}
	void Update () {
		// quando premo G per Grab
		if(Input.GetKeyDown(KeyCode.G) && primoGrabbato != null){
			(primoGrabbato.GetComponent<IGrabable>()).OnGrab();
			primoGrabbato.GetComponent<Rigidbody>().isKinematic = true;
			primoGrabbato.transform.parent = transform;
			primoGrabbato.GetComponent<Renderer>().material.color = Color.green;
		}

		if(Input.GetKeyUp(KeyCode.G) && primoGrabbato != null){
			primoGrabbato.GetComponent<Rigidbody>().isKinematic = false;
			primoGrabbato.GetComponent<Renderer>().material.color = Color.white;
			primoGrabbato.transform.parent = null;
		}
	}
}