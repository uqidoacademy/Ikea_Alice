using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitialParam : MonoBehaviour {


    #region Properties
    private Vector3 initialPosition;

    public Vector3 InitialPosition
    {
        get
        {
            return initialPosition;
        }
        set
        {
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
    }
      
     // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
