using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour {

	// Update is called once per frame
	Transform camera;

	Camera mainCam;

    void OnEnable() {
        CameraWakeUp.OnCameraWakeUp += OnCameraWakeUp;
    }

     void OnDisable() {
        CameraWakeUp.OnCameraWakeUp -= OnCameraWakeUp;
    }

    void OnCameraWakeUp(Camera _camera) {
        mainCam = _camera;
    }
 
     // Update is called once per frame
     void Update()
     {
         // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(mainCam.transform, -Vector3.up);
     }
}
