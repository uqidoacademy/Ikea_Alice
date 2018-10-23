using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactionable : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if ((this is IUsable))
        {
            IUsable usable = (this as IUsable);

            Debug.Log(collision.gameObject.tag);
            Debug.Log(usable.GetCollisionTags());
            Debug.Log(usable.CanBeUsed());
            if (usable.CanBeUsed() && TagIncluded(collision.gameObject.tag, usable.GetCollisionTags())) {
                usable.OnUse();
            }
        }

        /*if (this is IGrabable)
        {
            IGrabable grabable = (this as IGrabable);
            string tag = collision.gameObject.tag;
            Debug.Log(MainManager.Instance.HandTag);
            if (collision.gameObject.CompareTag(MainManager.Instance.HandTag ))
            {
                grabable.OnGrab();
            }
        } */
    }

    public void OnUngrab() 
    {

    }

    public void OnGrab()
    {
        // collega alla mano

        // TODO: Handle Hand Object

        //GameObject hand = GameObject.FindGameObjectWithTag(MainManager.Instance.HandTag) as GameObject;
        //this.transform.parent = hand.transform;
        //this.objectCanMove(false);
    }

    protected void objectCanMove(bool active)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = !active;
    }

    private bool TagIncluded(string targetTag, string[] tags)
    {
        foreach (string tag in tags)
            if (tag == targetTag)
                return true;
        return false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
