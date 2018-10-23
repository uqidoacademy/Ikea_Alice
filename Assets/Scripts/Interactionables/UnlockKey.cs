using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockKey : Interactionable, IGrabable, IUsable {


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
        return new string[] { "door" };
    }

    public void OnGrab()
    {
        // TODO:
    }

    public void OnUse()
    {
        if (EventManager.PreOpenDoor != null)
            EventManager.PreOpenDoor();
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
