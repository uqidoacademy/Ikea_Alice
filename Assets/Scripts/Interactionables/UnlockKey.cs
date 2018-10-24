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

    public void  OnGrab(Grabber ioTiGrabbo)
    {
        this.RemoveGravityAndRotation();
        this.SetMyParent(ioTiGrabbo.transform);
        this.AnimateSequence(ioTiGrabbo.secondHand.transform);
        this.SetMyParent(ioTiGrabbo.secondHand.transform);
        this.FreezeAllConstraints();
    }

    public void OnUse()
    {
        if (EventManager.PreOpenDoor != null)
            EventManager.PreOpenDoor();
    }

    public void OnUngrab(){
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
