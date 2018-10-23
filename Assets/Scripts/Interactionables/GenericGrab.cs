using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericGrab : Interactionable, IGrabable {

    public bool CanGrab()
    {
        return true;
    }

    public void OnGrab()
    {
        // TODO:
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
