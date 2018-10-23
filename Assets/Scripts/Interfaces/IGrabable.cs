
public interface IGrabable
{
    /// <summary>
    /// Returns wheater this instance is active
    /// </summary>
    /// <returns>Active</returns>
    bool CanGrab();


    /// <summary>
    /// What has to be done onGrab
    /// </summary>
    void OnGrab();
}