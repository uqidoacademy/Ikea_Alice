using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimizer : Interactionable, IUsable, IGrabable {

    private Transform genitore;
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

    public void OnUse()
    {
        if (EventManager.PreBecomeSmaller != null)
            EventManager.PreBecomeSmaller();
    }

    public void OnGrab (Grabber ioTiGrabbo) {
        genitore = this.transform.parent;
        this.RemoveGravityAndRotation ();
        this.SetMyParent (ioTiGrabbo.transform);
    }

    public void OnUngrab () {
        this.EnableGravityAndRotation ();
        this.SetMyParent (genitore);
    }
}
