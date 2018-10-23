
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
    void OnGrab();

    /// <summary>
    /// What has to be done on ungrab
    /// </summary>
    void OnUngrab();
}