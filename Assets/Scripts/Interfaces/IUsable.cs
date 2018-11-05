

using UnityEngine;

public interface IUsable
{
    /// <summary>
    /// Returns wheater this instance is active
    /// </summary>
    /// <returns>Active</returns>
    bool CanBeUsed();

    /// <summary>
    /// What animation should be used when the object is used
    /// </summary>
    /// <returns></returns>
    Grabber.HandAnimationType useAnimationType();

    /// <summary>
    /// What has to be done onUse
    /// </summary>
    void OnUse(Collision collision = null);

    /// <summary>
    /// Get array of tags to interact with
    /// </summary>
    /// <returns></returns>
    string[] GetCollisionTags();
}
