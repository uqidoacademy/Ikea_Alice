using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripManager : MonoBehaviour {

    #region State

    private PlayerState   keyRequiredSize = PlayerState.big, // always big for now
                          playerSize;
    private bool isKeyGrabbed = false;

    private void MakeKeyShine() {
        Debug.Log("Key shining");
    }

    private void MakeBiscuitShine() {
        Debug.Log("Biscuit shining");
    }

    private void MakePotionShine()
    {
        Debug.Log("Potion shining");
    }

    private void MakeDoorShine()
    {
        Debug.Log("Door shining");
    }

    private void StopShining()
    {
        Debug.Log("Stop shining");
    }

    #endregion

    private void UpdateKeyPosition(PlayerState size)
    {
        keyRequiredSize = size;
        TryMoveOn();
    }
    
    private void NextSize(bool bigger)
    {
        switch (playerSize) {
            case PlayerState.big: playerSize = (bigger ? PlayerState.big : PlayerState.medium); break;
            case PlayerState.medium: playerSize = (bigger ? PlayerState.big : PlayerState.small); break;
            case PlayerState.small: playerSize = (bigger ? PlayerState.medium : PlayerState.small); break;
        }
        TryMoveOn();
    }

    private void KeyGrabbed(bool isGrabbed)
    {
        isKeyGrabbed = isGrabbed;
        TryMoveOn();
    }

    private void TryMoveOn()
    {
        StopShining();
        switch(playerSize) {
            case PlayerState.big: {
                    if(isKeyGrabbed || keyRequiredSize != PlayerState.big) {
                        // non serve più essere grandi grandi
                        // cerca la pozione!
                        MakePotionShine();
                    } else {
                        // bisogna prendere la chiave
                        MakeKeyShine();
                    }
                } break;
            case PlayerState.medium: {
                    switch(keyRequiredSize)
                    {
                        case PlayerState.big: MakeBiscuitShine(); break; // bisogna diventare grandi per prendere la chiave
                        case PlayerState.medium: {
                                if(isKeyGrabbed) {
                                    // si può diventare piccoli ora!
                                    MakePotionShine();
                                } else {
                                    // si può prendere la chiave
                                    MakeKeyShine();
                                }
                            } break;
                        case PlayerState.small: MakePotionShine(); break; // bisogna diventare piccoli per prendere la chiave
                    }
                } break;
            case PlayerState.small: {
                    if(isKeyGrabbed) {
                        // si può aprire la porta
                        MakeDoorShine();
                    } else if(keyRequiredSize == PlayerState.small)
                    {
                        // si può prendere la chiave
                        MakeKeyShine();
                    } else
                    {
                        // bisogna crescere
                        MakeBiscuitShine();
                    }
                } break;
        }
    }
    
    void Start () {
        EventManager.OnKeyNeedState += UpdateKeyPosition;
        EventManager.PostBecomeBigger += delegate () { NextSize(true); };
        EventManager.PostBecomeSmaller += delegate () { NextSize(false); };
        EventManager.OnKeyGrabbed += KeyGrabbed;
	}
}
