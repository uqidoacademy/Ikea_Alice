using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MagicDoor : Interactionable, IUsable {

    [SerializeField] GameObject hingeDoor;

    [SerializeField] float angoloAperturaPorta = 90.0f;
    [SerializeField] float tempoAperturaPorta = 3f;

    public bool CanBeUsed()
    {
        return true;
    }
    private void OnEnable()
    {
        EventManager.PreOpenDoor += OpenDoor;
    }

    public Grabber.HandAnimationType useAnimationType()
    {
        return Grabber.HandAnimationType.none;
    }

    public string[] GetCollisionTags()
    {
        return new string[] { "UnlockKey" };
    }

    public void OnUse()
    {
        EventManager.PreOpenDoor += OpenDoor;
       
    }

    // Use this for initialization
    void Start () {
	}

    void OpenDoor()
    {
        if(hingeDoor != null)
        hingeDoor.transform.DORotate(new Vector3(0, angoloAperturaPorta, 0), tempoAperturaPorta);
        Debug.Log("Open door");
        // after rotation has been done trigger event
        if (EventManager.PostOpenDoor != null) EventManager.PostOpenDoor();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
