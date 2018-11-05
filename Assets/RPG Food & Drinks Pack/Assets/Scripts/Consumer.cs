using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : Interactionable, IUsable, IGrabable
{
    public SizeOperation _currentOperationSize;
    public GameObject[] portions;
    [SerializeField] GameObject cork;
    int currentIndex;
    float lastChange;
    [SerializeField] float interval = 1f;
    [SerializeField] AudioSource ConsumeAudioSource;
    private ParticleSystem EatingFX;
    public ParticleSystem EatingFXprefab;


    private bool IsEating = false;
    bool handAttached = false;
    

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
        if (EatingFXprefab != null)
        {
            EatingFX = Instantiate(EatingFXprefab, transform).GetComponent<ParticleSystem>();
            EatingFX.transform.SetSiblingIndex(0);
        }

        bool skipFirst = transform.childCount == 5;
        bool skipSecond = transform.childCount == 6;
        portions = new GameObject[skipFirst ? transform.childCount-1 : transform.childCount];
        portions = new GameObject[skipSecond ? transform.childCount - 2 : transform.childCount -1];

        for (int i = 0; i < portions.Length; i++)
        {
           
            portions[i] = transform.GetChild(skipFirst ? i + 1 : i).gameObject;
            if (portions[i].activeInHierarchy)
                currentIndex = i;
        }

        if (GetComponent<Valve.VR.InteractionSystem.Interactable>() != null)
        {
            GetComponent<Valve.VR.InteractionSystem.Interactable>().onAttachedToHand += attachedToHand;
            GetComponent<Valve.VR.InteractionSystem.Interactable>().onDetachedFromHand += detachedFromHand;
        }
    }

    private void attachedToHand(Valve.VR.InteractionSystem.Hand hand) 
    {
        handAttached = true;
        hand.TriggerHapticPulse(1000);
    }

    private void detachedFromHand(Valve.VR.InteractionSystem.Hand hand)
    {
        handAttached = false;
        hand.TriggerHapticPulse(1000);
    }

    void Update()
    {
        if (IsEating)
        {
            if (cork != null)
            {
                cork.SetActive(false);
            }

            if (Time.time - lastChange > interval)
            {
                float timeLeft = Time.time - lastChange;
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
        if(EatingFX)
             EatingFX.Play();

        if (currentIndex < portions.Length)
            portions[currentIndex].SetActive(false);

        
        currentIndex++;

        MainManager.Instance.ManagerAudio.playEffectOnce(ConsumeAudioSource);

        if (currentIndex > portions.Length)
        {
            currentIndex = 0;
            // Destroy(gameObject);
        }

        else if (currentIndex  == portions.Length)
        {
            if (EventManager.PreBecomeBigger != null && _currentOperationSize == SizeOperation.Maximazer) {
                EventManager.PreBecomeBigger();
                //Aggiunta PLAY timeline dopo bevuta pozione
                MainManager.Instance.scenaDopoPozione.Play();
            }
               

            if (EventManager.PreBecomeSmaller != null && _currentOperationSize == SizeOperation.Minimazer)
                EventManager.PreBecomeSmaller();
            
            IsEating = false;
            if (EatingFX)
                EatingFX.Stop();
            Destroy(gameObject);
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

    public override void OnUse(Collision collision)
    {
        if (collision.gameObject.CompareTag("Head") && handAttached)
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
    /*
    void OnCollisionExit(Collision other)
    {
      //  if (other.gameObject.CompareTag("Head"))
            
    }*/
}
public enum SizeOperation
{
    Maximazer = 0,
    Minimazer = 1,
}

