﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObjects : MonoBehaviour {

    public float respawnTime = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Interactionable>())
        {
            collision.gameObject.transform.DOMove(collision.gameObject.GetComponent<Interactionable>().InitialPosition, respawnTime);
            collision.gameObject.transform.DORotate(collision.gameObject.GetComponent<Interactionable>().InitialRotation, respawnTime);
            collision.gameObject.transform.DOScale(collision.gameObject.GetComponent<Interactionable>().InitialScale, respawnTime);
        }
    }
}
