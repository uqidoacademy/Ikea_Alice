using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	private GameObject primoGrabbato;
	private bool grabbing = false;
    private Transform grabbedOriginalParent = null;
    private Transform grabbedChild = null;
    private Vector3 initialScale;

	public GameObject secondHand;

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
			LoseObject();
		}
	}
	void Update () {

		if(Input.GetKeyDown(KeyCode.Mouse0) && !grabbing && primoGrabbato != null){

			(primoGrabbato.GetComponent<IGrabable>()).OnGrab(this);
			primoGrabbato.GetComponent<Renderer>().material.color = Color.green;
			grabbing = true;

		} 

		if(Input.GetKeyUp(KeyCode.Mouse0) && primoGrabbato != null && grabbing){

			LoseObject();
			grabbing = false;

        }

		if (Input.GetKeyDown(KeyCode.Mouse1) && primoGrabbato != null && grabbing && primoGrabbato.GetComponent<IUsable>() != null) {
            (primoGrabbato.GetComponent<IUsable>()).OnUse();
        }

	}

	void LoseObject(){
			(primoGrabbato.GetComponent<IGrabable>()).OnUngrab();
			primoGrabbato.GetComponent<Renderer>().material.color = Color.white;
			primoGrabbato = null;
	}
}