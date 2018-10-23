using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maximizer : Interactionable, IUsable, IGrabable {
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
        return new string[] { MainManager.Instance.MouthTag };
    }

    public void OnUse()
    {
        EventManager.PreBecomeBigger();
    }
}
