﻿
using UnityEngine;

public interface IGrabable
{
    /// <summary>
    /// Returns wheater this instance is active
    /// </summary>
    /// <returns>Active</returns>
    bool CanGrab();

    /// <summary>
    /// What has to be done on grab
    /// </summary>
    void OnGrab(Valve.VR.InteractionSystem.Hand hand);

    /// <summary>
    /// What has to be done on ungrab
    /// </summary>
    void OnUngrab();

    //TODO definire default se grabbato
    //bool AmIGrabbed();
}