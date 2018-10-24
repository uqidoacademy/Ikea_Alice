﻿using System.Collections;
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

    public string[] GetCollisionTags () {
        return new string[] { };
    }

    public void OnUse () {
        if (EventManager.PreBecomeBigger != null)
            EventManager.PreBecomeBigger ();
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