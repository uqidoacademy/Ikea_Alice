using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	private Collider primoCollidato;

	void OnTriggerEnter (Collider oggettoGrabbabile) {
		if(!primoCollidato){
			primoCollidato = oggettoGrabbabile;
			primoCollidato.GetComponent<Renderer>().material.color = Color.blue;
		}
	}

	void OnTriggerExit (Collider oggettoGrabbabile) {
		if(oggettoGrabbabile == primoCollidato){
			primoCollidato.GetComponent<Renderer>().material.color = Color.white;
			primoCollidato = null;
			}
	}
	void Update () {
		if(primoCollidato)
			Debug.Log(primoCollidato.name);
	}
}