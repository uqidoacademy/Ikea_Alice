using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Interactionable : MonoBehaviour {
    [SerializeField]
    protected AudioSource SourceAudio;
    [SerializeField]
    protected AudioClip UseClip;

    #region Properties
    private Vector3 initialPosition;

    public Vector3 InitialPosition
    {
        get {
            return initialPosition;
        }
        set {
            if (value != initialPosition)
            {
                initialPosition = value;
            }
        }
    }

    private Vector3 initialScale;

    public Vector3 InitialScale
    {
        get
        {
            return initialScale;
        }
        set
        {
            if (value != initialScale)
            {
                initialScale = value;
            }
        }
    }

    private Vector3 initialRotation;

    public Vector3 InitialRotation
    {
        get
        {
            return initialRotation;
        }
        set
        {
            if (value != initialRotation)
            {
                initialRotation = value;
            }
        }
    }


    private Transform initialParent;

    public Transform InitialParent
    {
        get
        {
            return initialParent;
        }
        set
        {
            if (value != initialParent)
            {
                initialParent = value;
            }
        }
    }
    #endregion

    public void Awake()
    {
        SetUp();
    }

    private void SetUp()
    {
        InitialPosition = transform.position;
        InitialScale = transform.localScale;
        InitialRotation = transform.eulerAngles;
        InitialParent = transform.parent;

       // gameObject.layer = 10;
    }

    public virtual void OnUse(Collision collision = null)
    {
        if (SourceAudio != null)
        {
            SourceAudio.clip = UseClip;
            SourceAudio.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if ((this is IUsable))
        {
            IUsable usable = (this as IUsable);
            
            if (usable.CanBeUsed() && TagIncluded(collision.gameObject.tag, usable.GetCollisionTags())) {
                
                usable.OnUse(collision);
                
            }
        }

        if (this is IGrabable)
        {
            //IGrabable grabable = (this as IGrabable);
            //string tag = collision.gameObject.tag;
            //Debug.Log(MainManager.Instance.HandTag);
            //if (collision.gameObject.CompareTag(MainManager.Instance.HandTag ))
            //{
            //   // grabable. OnGrab(GameObject collision.gameObject);
            //}
        } 
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (this is IUsable)
        {
            IUsable usable = (this as IUsable);

            if (usable.CanBeUsed() && TagIncluded(other.gameObject.tag, usable.GetCollisionTags()))
            {
                Debug.Log("LA CHIAVE ENTRATA NELLA PORTA");
                usable.OnUse();
            }
        }
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
    
    public bool handAttached = false;
    private void OnEnable()
    {
        if (GetComponent<Valve.VR.InteractionSystem.Interactable>() != null)
        {
            GetComponent<Valve.VR.InteractionSystem.Interactable>().onAttachedToHand += attachedToHandEvent;
            GetComponent<Valve.VR.InteractionSystem.Interactable>().onDetachedFromHand += detachedFromHandEvent;
        }
    }

    private void attachedToHandEvent(Valve.VR.InteractionSystem.Hand hand)
    {
        handAttached = false;
    }

    private void detachedFromHandEvent(Valve.VR.InteractionSystem.Hand hand)
    {
        handAttached = true;
    }

}

public static class InteractionableExt
{
    public static void RemoveGravityAndRotation(this Interactionable _grabbed)
    {
        _grabbed.GetComponent<Rigidbody>().useGravity = false;
		_grabbed.GetComponent<Rigidbody>().freezeRotation = true;
    }

    public static void EnableGravityAndRotation(this Interactionable _grabbed)
    {
        _grabbed.GetComponent<Rigidbody>().useGravity = true;
		_grabbed.GetComponent<Rigidbody>().freezeRotation = false;
    }

    public static void FreezeAllConstraints(this Interactionable _grabbed){
        _grabbed.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public static Transform SetMyParent(this Interactionable _grabbed,Transform padre){
        Transform vecchioPadre = _grabbed.transform.parent;
        _grabbed.transform.parent = padre;
        return vecchioPadre;
    }

    public static void AnimateSequence(this Interactionable _grabbed,Transform to)
    {
        _grabbed.transform.DOLocalMove(to.localPosition, 2f);
    }
    
}