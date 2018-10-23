

public interface IUsable
{
    /// <summary>
    /// Returns wheater this instance is active
    /// </summary>
    /// <returns>Active</returns>
    bool CanBeUsed();

    /// <summary>
    /// What has to be done onUse
    /// </summary>
    void OnUse();

    /// <summary>
    /// Get array of tags to interact with
    /// </summary>
    /// <returns></returns>
    string[] GetCollisionTags();
}
