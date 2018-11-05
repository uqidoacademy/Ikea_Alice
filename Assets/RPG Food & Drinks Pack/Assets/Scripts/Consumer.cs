using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : Interactionable, IUsable, IGrabable
{

    public GameObject[] portions;
    [SerializeField] GameObject cork;
    int currentIndex;
    float lastChange;
    [SerializeField] float interval = 1f;

    private bool IsEating = false;

    /*
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Head"))
        {           
            if(cork != null)
            {
                cork.SetActive(false);
            }
           

            if (Time.time - lastChange > interval)
            {
                float timeLeft = Time.time - lastChange;
                Debug.Log(timeLeft);
                Consume();
                lastChange = Time.time;
            }
        }

        

    }
    */


    void Start()
    {
        bool skipFirst = transform.childCount > 4;
        portions = new GameObject[skipFirst ? transform.childCount-1 : transform.childCount];
        for (int i = 0; i < portions.Length; i++)
        {
           
            portions[i] = transform.GetChild(skipFirst ? i + 1 : i).gameObject;
            if (portions[i].activeInHierarchy)
                currentIndex = i;
        }
    }

    void Update()
    {
        if ( IsEating)
        {
            Debug.Log("MANGIANDO");


            if (Time.time - lastChange > interval)
            {
                float timeLeft = Time.time - lastChange;
                Debug.Log(timeLeft);
                Consume();
                lastChange = Time.time;
            }
        }
        /* if (Time.time - lastChange > interval)
         {
             Consume();
             lastChange = Time.time;
         }*/
    }

    void Consume()
    {
        if (currentIndex != portions.Length)
            portions[currentIndex].SetActive(false);
        
        currentIndex++;
        if (currentIndex > portions.Length)
        {
            currentIndex = 0;
            // Destroy(gameObject);
        }

        else if (currentIndex  == portions.Length)
        {
            if (EventManager.PreBecomeBigger != null)
                EventManager.PreBecomeBigger();

            return;
        }
       portions[currentIndex].SetActive(true);
    }

    public bool CanBeUsed()
    {
        return true;
    }

    public Grabber.HandAnimationType useAnimationType()
    {
        throw new System.NotImplementedException();
    }

    public string[] GetCollisionTags()
    {
        return new string[] { "Head" };
    }

    public bool CanGrab()
    {
        return true;
    }

    public new void OnUse(Collision collision)
    {
        if (collision.gameObject.CompareTag("Head"))
        {
            base.OnUse(collision);
            IsEating = true;
        }
        /*
        if (EventManager.PreBecomeBigger != null)
            EventManager.PreBecomeBigger();

        */

    }

    public void OnGrab(GameObject ioTiGrabbo)
    {
        /*
        genitore = this.transform.parent;
        this.RemoveGravityAndRotation();
        this.SetMyParent(ioTiGrabbo.transform);
        */
    }


    public void OnUngrab()
    {
        /*

        this.EnableGravityAndRotation();
        this.SetMyParent(genitore);
        */
    }
}
