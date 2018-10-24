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
   // TODO [SerializeField] TextMesh tipText;
   

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

        tipText.text = "Ti consiglio:\n";


	}
}
