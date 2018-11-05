using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{

    private GameObject primoGrabbato;
    private bool grabbing = false;
    private Transform grabbedOriginalParent = null;
    private Transform grabbedChild = null;
    private Vector3 initialScale;
    public GameObject oggettoSelezionato;

    public GameObject secondHand;

    private void Start()
    {
        InitialHandScale = transform.localScale;
        InitialHandPosition = transform.localPosition;
        InitialHandRotation = transform.localRotation.eulerAngles;
        InitialSecondHandScale = secondHand.transform.localScale;
        InitialSecondHandPosition = secondHand.transform.localPosition;
        InitialSecondHandRotation = secondHand.transform.localRotation.eulerAngles;
    }

    void OnTriggerEnter(Collider oggettoForseGrabbabile)
    {
        IGrabable tempGrab = oggettoForseGrabbabile.gameObject.GetComponent<IGrabable>();
        if (primoGrabbato == null && tempGrab != null && tempGrab.CanGrab())
        {
            primoGrabbato = oggettoForseGrabbabile.gameObject;
            initialScale = primoGrabbato.transform.localScale;
            oggettoForseGrabbabile.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    void OnTriggerExit(Collider oggettoGrabbabile)
    {
        if (oggettoGrabbabile.gameObject == primoGrabbato && !grabbing)
        {
            LoseObject();
        }
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && !grabbing && primoGrabbato != null)
        {

           // (primoGrabbato.GetComponent<IGrabable>()).OnGrab(this);
            primoGrabbato.GetComponent<Renderer>().material.color = Color.green;
            oggettoSelezionato = primoGrabbato.gameObject;
            grabbing = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && primoGrabbato != null && grabbing)
        {

            LoseObject();
            grabbing = false;

        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && primoGrabbato != null && grabbing && primoGrabbato.GetComponent<IUsable>() != null)
        {
            animate(primoGrabbato.GetComponent<IUsable>().useAnimationType(), () =>
            {
               // (primoGrabbato.GetComponent<IUsable>()).OnUse();
            });

        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            animateUseKey(() => { });
        }

    }

    void LoseObject()
    {
        (primoGrabbato.GetComponent<IGrabable>()).OnUngrab();
        primoGrabbato.GetComponent<Renderer>().material.color = Color.white;
        primoGrabbato = null;
    }

    #region Animations

    private Vector3 InitialHandScale;
    private Vector3 InitialHandPosition;
    private Vector3 InitialHandRotation;
    private Vector3 InitialSecondHandScale;
    private Vector3 InitialSecondHandPosition;
    private Vector3 InitialSecondHandRotation;
    [SerializeField] const float AnimationTime = 1.0f;
    [SerializeField] float AnimationScaleToEat = 0.005f;
    [SerializeField] float AnimationScaleToUnlockKey = 0.0025f;

    [SerializeField] Vector3 AnimationRotationScaleEat = new Vector3(1, 1, 1);
    [SerializeField] Vector3 AnimationMoveScaleEat = new Vector3(1, 1, 1);
    [SerializeField] Vector3 AnimationRotationScaleUnlockKey = new Vector3(1, 1, 1);
    [SerializeField] Vector3 AnimationMoveScaleUnlockKey = new Vector3(1, 1, 1);

    public enum HandAnimationType
    {
        eat,
        useKey,
        none
    };

    public void animate(HandAnimationType animationType, Action callback)
    {
        switch (animationType)
        {
            case HandAnimationType.eat: animateEat(callback); break;
            case HandAnimationType.useKey: animateUseKey(callback); break;
            default: callback(); break;
        }
    }


    private void animateEat(Action callback)
    {
        Sequence animationSequence = DOTween.Sequence();
        animationSequence.Append(transform.DOScale(AnimationScaleToEat, AnimationTime));
        animationSequence.Join(transform.DOLocalRotate(new Vector3(-25 * AnimationRotationScaleEat.x, -320 * AnimationRotationScaleEat.y, -200 * AnimationRotationScaleEat.z), AnimationTime));
        animationSequence.Join(transform.DOLocalMove(new Vector3(0.20f * AnimationMoveScaleEat.x, -0.14f * AnimationMoveScaleEat.y, 0.68f * AnimationMoveScaleEat.z), AnimationTime));
        animationSequence.Play();

        animationSequence.OnComplete(() =>
        {
            if (grabbing)
                callback();

            animateToOriginalPosition();
        });
    }

    private void animateUseKey(Action callback)
    {
        Sequence animationSequence = DOTween.Sequence();
        animationSequence.Append(secondHand.transform.DOScale(new Vector3(AnimationScaleToUnlockKey, AnimationScaleToUnlockKey, -AnimationScaleToUnlockKey), AnimationTime));
        animationSequence.Join(secondHand.transform.DOLocalRotate(new Vector3(18 * AnimationRotationScaleUnlockKey.x, -272 * AnimationRotationScaleUnlockKey.y, -189 * AnimationRotationScaleUnlockKey.z), AnimationTime));
        animationSequence.Join(secondHand.transform.DOLocalMove(new Vector3(-0.15f * AnimationMoveScaleUnlockKey.x, -0.17f * AnimationMoveScaleUnlockKey.y, 1.25f * AnimationMoveScaleUnlockKey.z), AnimationTime));
        animationSequence.Play();

        animationSequence.OnComplete(() =>
        {
            callback();
            animateToOriginalPositionSecondHand();
        });
    }
    private void animateToOriginalPosition()
    {
        Sequence animationSequence = DOTween.Sequence();
        animationSequence.Append(transform.DOScale(InitialHandScale, AnimationTime));
        animationSequence.Join(transform.DOLocalRotate(InitialHandRotation, AnimationTime));
        animationSequence.Join(transform.DOLocalMove(InitialHandPosition, AnimationTime));
        animationSequence.Play();
    }

    private void animateToOriginalPositionSecondHand()
    {
        Sequence animationSequence = DOTween.Sequence();
        animationSequence.Append(secondHand.transform.DOScale(InitialSecondHandScale, AnimationTime));
        animationSequence.Join(secondHand.transform.DOLocalRotate(InitialSecondHandRotation, AnimationTime));
        animationSequence.Join(secondHand.transform.DOLocalMove(InitialSecondHandPosition, AnimationTime));
        animationSequence.Play();
    }

    #endregion

}

