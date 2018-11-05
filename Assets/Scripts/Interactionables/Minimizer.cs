using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimizer : Interactionable, IUsable, IGrabable {

    private Transform genitore;
    public bool CanBeUsed()
    {
        return true;
    }

    public Grabber.HandAnimationType useAnimationType()
    {
        return Grabber.HandAnimationType.eat;
    }

    public bool CanGrab()
    {
        return true;
    }

    public string[] GetCollisionTags()
    {
        return new string[] { "Head" };
    }

    public new void OnUse()
    {
        base.OnUse();
        if (EventManager.PreBecomeSmaller != null)
            EventManager.PreBecomeSmaller();
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
