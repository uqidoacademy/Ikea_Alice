using System;

public static class EventManager
{
    /*
    #region Singleton

    private EventManager()
    {
        // Prevent outside instantiation
    }

    private static readonly EventManager _singleton = new EventManager();
    public static EventManager Instance
    {
        get { return _singleton; }
    }

    #endregion
    */

    public delegate void BecomeBiggerEvent();

    /// <summary>
    ///Evento scatenato quando si diventa grandi
    /// </summary>
    public static BecomeBiggerEvent PreBecomeBigger;


    /// <summary>
    /// Evento scatenato dopo che si è diventati grandi
    /// </summary>
    public static BecomeBiggerEvent PostBecomeBigger;

    public delegate void BecomeSmallerEvent();

    /// <summary>
    ///Evento scatenato quando si diventa piccoli
    /// </summary>
    public static BecomeSmallerEvent PreBecomeSmaller;


    /// <summary>
    /// Evento scatenato dopo che si è diventati piccoli
    /// </summary>
    public static BecomeSmallerEvent PostBecomeSmaller;

    public delegate void ObjectInteraction();

    public static ObjectInteraction PreOpenDoor;
    public static ObjectInteraction PostOpenDoor;

    #region Key position events
    // questi eventi vengono chiamati quando la chiave cambia posizione e per essere raggiungibile il player deve trovarsi in un determinato stato

    public delegate void KeyMoved(PlayerState size);
    public delegate void KeyGrabbed(bool isGrabbed);
    public static KeyMoved OnKeyNeedState;
    public static KeyGrabbed OnKeyGrabbed;
    #endregion
}