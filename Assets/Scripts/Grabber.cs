using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	private GameObject primoGrabbato;
	private bool grabbing = false;
    private Transform grabbedOriginalParent = null;
    private Transform grabbedChild = null;
    private Vector3 initialScale;


	void OnTriggerEnter (Collider oggettoForseGrabbabile) {
		IGrabable tempGrab = oggettoForseGrabbabile.gameObject.GetComponent<IGrabable>();
		if(primoGrabbato == null && tempGrab != null && tempGrab.CanGrab()){          
            primoGrabbato = oggettoForseGrabbabile.gameObject;
            initialScale = primoGrabbato.transform.localScale;
            oggettoForseGrabbabile.gameObject.GetComponent<Renderer>().material.color = Color.blue;
		}
	}

	void OnTriggerExit (Collider oggettoGrabbabile) {
		if(oggettoGrabbabile.gameObject == primoGrabbato && !grabbing){
			primoGrabbato.GetComponent<Renderer>().material.color = Color.white;
            primoGrabbato = null;
		}
	}
	void Update () {
		// quando premo G per Grab
		if(Input.GetKeyDown(KeyCode.Mouse0) && !grabbing && primoGrabbato != null){
			(primoGrabbato.GetComponent<IGrabable>()).OnGrab();
			primoGrabbato.GetComponent<Rigidbody>().isKinematic = true;    
            grabbedOriginalParent = primoGrabbato.transform.parent;
            primoGrabbato.transform.parent = transform.GetChild(0);
            primoGrabbato.GetComponent<Renderer>().material.color = Color.green;
			grabbing = true;
		} 

		if(!Input.GetKey(KeyCode.Mouse0) && primoGrabbato != null && grabbing){
			primoGrabbato.GetComponent<Rigidbody>().isKinematic = false;
			primoGrabbato.GetComponent<Renderer>().material.color = Color.white;
			primoGrabbato.transform.parent = grabbedOriginalParent.transform;
            primoGrabbato.transform.localScale = initialScale;
            grabbing = false;
        }

		if (Input.GetKeyDown(KeyCode.Mouse1) && primoGrabbato != null && grabbing && primoGrabbato.GetComponent<IUsable>() != null) {
            (primoGrabbato.GetComponent<IUsable>()).OnUse();
        }

      // 
	}
}