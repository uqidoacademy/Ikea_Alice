using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maximizer : Interactionable, IUsable, IGrabable {

    

    private Transform genitore;
    public bool CanBeUsed () {
        return true;
    }

    public bool CanGrab () {
        return true;
    }

    public Grabber.HandAnimationType useAnimationType()
    {
        return Grabber.HandAnimationType.eat;
    }

    public string[] GetCollisionTags () {
        return new string[] { "Head"};
    }

    public new void OnUse (Collision collision) {
        base.OnUse(collision);
        if (EventManager.PreBecomeBigger != null)
            EventManager.PreBecomeBigger ();

        
    }

    public void OnGrab (GameObject ioTiGrabbo) {
        genitore = this.transform.parent;
        this.RemoveGravityAndRotation ();
        this.SetMyParent (ioTiGrabbo.transform);
    }

    public void OnUngrab () {
        this.EnableGravityAndRotation ();
        this.SetMyParent (genitore);
    }

}