using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimizer : Interactionable, IUsable, IGrabable {

    public bool CanBeUsed()
    {
        return true;
    }

    public bool CanGrab()
    {
        return true;
    }

    public string[] GetCollisionTags()
    {
        return new string[] {  };
    }

    public void OnGrab()
    {
        // collega alla mano
    }

    public void OnUse()
    {
        if (EventManager.PreBecomeSmaller != null)
            EventManager.PreBecomeSmaller();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
