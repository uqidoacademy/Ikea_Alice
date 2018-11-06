using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour {

	// Update is called once per frame
	 private Transform camera;

	 public Camera mainCam;
 
     // Use this for initialization
     void Start () {
 
         camera = mainCam.transform;
 
     }
 
     // Update is called once per frame
     void Update()
     {
         // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(camera, -Vector3.up);
     }
}
