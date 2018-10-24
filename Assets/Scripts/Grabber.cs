using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	private GameObject primoGrabbato;
	private bool grabbing = false;
    private Transform grabbedOriginalParent = null;
    private Transform grabbedChild = null;
    private Vector3 initialScale;

	public GameObject secondHand;

    private void Start()
    {
        InitialHandScale = transform.localScale.x;
        InitialHandPosition = transform.localPosition;
        InitialHandRotation = transform.localRotation.eulerAngles;
    }

    void OnTriggerEnter (Collider oggettoForseGrabbabile) {
		IGrabable tempGrab = oggettoForseGrabbabile.gameObject.GetComponent<IGrabable>();
		if(primoGrabbato == null && tempGrab != null && tempGrab.CanGrab()){          
            primoGrabbato = oggettoForseGrabbabile.gameObject;
            initialScale = primoGrabbato.transform.localScale;
            oggettoForseGrabbabile.gameObject.GetComponent<Renderer>().material.color = Color.blue;
		}
	}

	void OnTriggerExit (Collider oggettoGrabbabile) {
		if(oggettoGrabbabile.gameObject == primoGrabbato && !grabbing){
			LoseObject();
		}
	}
	void Update () {

		if(Input.GetKeyDown(KeyCode.Mouse0) && !grabbing && primoGrabbato != null){

			(primoGrabbato.GetComponent<IGrabable>()).OnGrab(this);
			primoGrabbato.GetComponent<Renderer>().material.color = Color.green;
			grabbing = true;
		} 

		if(Input.GetKeyUp(KeyCode.Mouse0) && primoGrabbato != null && grabbing ){

			LoseObject();
			grabbing = false;

        }
        IUsable usable = primoGrabbato.GetComponent<IUsable>();

        if (Input.GetKeyDown(KeyCode.Mouse1) && primoGrabbato != null && grabbing && usable != null) {
            animate(usable.useAnimationType(), () =>
            {
                (primoGrabbato.GetComponent<IUsable>()).OnUse();
            });
            
        }

	}

	void LoseObject(){
			(primoGrabbato.GetComponent<IGrabable>()).OnUngrab();
			primoGrabbato.GetComponent<Renderer>().material.color = Color.white;
			primoGrabbato = null;
	}

    #region Animations

    float InitialHandScale;
    private Vector3 InitialHandPosition;
    private Vector3 InitialHandRotation;
    [SerializeField] const float AnimationTime = 1.0f;
    [SerializeField] float AnimationScaleTo = 0.005f;

    [SerializeField] Vector3 AnimationRotationScale = new Vector3(1, 1, 1);
    [SerializeField] Vector3 AnimationMoveScale = new Vector3(1, 1, 1);

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
            default: callback(); break;
        }
    }


    private void animateEat(Action callback)
    {
        Sequence animationSequence = DOTween.Sequence();
        animationSequence.Append(transform.DOScale(AnimationScaleTo, AnimationTime));
        animationSequence.Join(transform.DOLocalRotate(new Vector3(-25 * AnimationRotationScale.x, -320 * AnimationRotationScale.y, -200 * AnimationRotationScale.z), AnimationTime));
        animationSequence.Join(transform.DOLocalMove(new Vector3(0.20f * AnimationMoveScale.x, -0.14f * AnimationMoveScale.y, 0.68f * AnimationMoveScale.z), AnimationTime));
        animationSequence.Play();

        animationSequence.OnComplete(() =>
        {
            if (grabbing)
                callback();

            animateToOriginalPosition();
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

    #endregion

}

