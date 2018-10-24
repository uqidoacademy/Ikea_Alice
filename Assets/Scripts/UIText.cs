using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour {

    [SerializeField] TextMesh statusText;
    [SerializeField] TextMesh actualDoingText;
    [SerializeField] TextMesh tipText;

    private PlayerStateMachine playerStateMachine;
    private Grabber grabber;
   
   

    // Use this for initialization
    void Awake () {

        playerStateMachine = FindObjectOfType<PlayerStateMachine>();
        grabber = FindObjectOfType<Grabber>();

	}
	
	// Update is called once per frame
	void Update () {

        statusText.text = "Actual status\n" + "     " + playerStateMachine.CurrentState;

        if (grabber.oggettoSelezionato != null)
            actualDoingText.text = "Hai raccolto\n" + "   " + grabber.oggettoSelezionato.name; 

        GiveTips();

	}

    void GiveTips()
    {
        switch (playerStateMachine.CurrentState)
        {
            case PlayerState.small:
                tipText.text = " SUGGERIMENTO:\nPersone piccole \npassano attraverso \nporte piccole...";
                break;

            case PlayerState.medium:
                tipText.text = " SUGGERIMENTO:\nPersone alte\nraggiungono\nposti alti...";

                break;

            case PlayerState.big:
                tipText.text = " SUGGERIMENTO:\nGuardarti intorno\nè la chiave\ndella storia...";
                break;
        }
    }
}
