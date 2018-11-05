using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockKey : Interactionable, IGrabable, IUsable {

    private bool keyInDoor = false;

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

    public void  OnGrab(GameObject ioTiGrabbo)
    {
        this.RemoveGravityAndRotation();
        this.SetMyParent(ioTiGrabbo.transform);
        //this.AnimateSequence(ioTiGrabbo.secondHand.transform);
        //this.SetMyParent(ioTiGrabbo.secondHand.transform);
        this.FreezeAllConstraints();
        if(EventManager.OnKeyGrabbed != null) EventManager.OnKeyGrabbed(true);
    }

    public override void OnUse(Collision collision = null)
    {
        base.OnUse();
        //this.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        Debug.Log("Entrata la chiave");
        keyInDoor = true;
        
    }

    public void OnUngrab(){
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (keyInDoor==true) // && this.gameObject.transform.eulerAngles.z > 90f)
        {
            Debug.Log("Dovrebbe finire il gioco");
            MainManager.Instance.MainGrabber.animate(Grabber.HandAnimationType.useKey, () => {
                if (EventManager.PreOpenDoor != null)
                    EventManager.PreOpenDoor();
            });

        }
        */

		
	}

    private void OnCollisionExit (Collision collision)
    {
        keyInDoor = false;
        
    }
}
