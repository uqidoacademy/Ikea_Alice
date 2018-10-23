using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDoor : Interactionable, IUsable {

    public bool CanBeUsed()
    {
        return true;
    }

    public string[] GetCollisionTags()
    {
        return new string[] { "UnlockKey" };
    }

    public void OnUse()
    {
        // TODO: open door
        Debug.Log("Open door");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
