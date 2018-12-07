using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Avvisa quando la camera viene attivata
[RequireComponent(typeof(Camera))]
public class CameraWakeUp : MonoBehaviour {

	public delegate void CameraEvent(Camera camera);
	public static CameraEvent OnCameraWakeUp;

	// Use this for initialization
	void Start () {
		if(OnCameraWakeUp != null) {
			OnCameraWakeUp(GetComponent<Camera>());
		}
	}

}
