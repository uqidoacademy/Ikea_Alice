using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockKey : Interactionable, IGrabable, IUsable {

    public bool CanBeUsed()
    {
        return true;
    }

    public Grabber.HandAnimationType useAnimationType()
    {
        return Grabber.HandAnimationType.useKey;
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
        if(EventManager.OnKeyGrabbed != null) EventManager.OnKeyGrabbed(true);
    }

    public void OnUse()
    {
        this.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
       
        
    }

    public void OnUngrab(){
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        if (this.gameObject.transform.eulerAngles.z == 90)
        {
            MainManager.Instance.MainGrabber.animate(Grabber.HandAnimationType.useKey, () => {
                if (EventManager.PreOpenDoor != null)
                    EventManager.PreOpenDoor();
            });
        }
    }
}
