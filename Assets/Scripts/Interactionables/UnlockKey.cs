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

    public void  OnGrab(Valve.VR.InteractionSystem.Hand hand)
    {
        this.RemoveGravityAndRotation();
        //this.SetMyParent(ioTiGrabbo.transform);
        //this.AnimateSequence(ioTiGrabbo.secondHand.transform);
        //this.SetMyParent(ioTiGrabbo.secondHand.transform);
        //this.FreezeAllConstraints();
        //if(EventManager.OnKeyGrabbed != null) EventManager.OnKeyGrabbed(true);
    }

    public override void OnUse(Collision collision = null)
    {
        if (!handAttached) return;

        base.OnUse();
        //this.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        Debug.Log("Entrata la chiave");
        
        keyInDoor = true;
        if (EventManager.PreOpenDoor != null)
            EventManager.PreOpenDoor();

    }

    public void OnUngrab(){
    }
    
    // Use this for initialization
    void Start () {
		        Valve.VR.InteractionSystem.Interactable interactable = GetComponent<Valve.VR.InteractionSystem.Interactable>();
        if(interactable != null) interactable.onAttachedToHand += OnGrab;
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

    void OnDisable()
    {
        Valve.VR.InteractionSystem.Interactable interactable = GetComponent<Valve.VR.InteractionSystem.Interactable>();
        if(interactable != null) interactable.onAttachedToHand -= OnGrab;
    }
}
