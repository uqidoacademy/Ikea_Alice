using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripManager : MonoBehaviour {

    #region State

    private PlayerState   keyRequiredSize,
                          playerSize;
    private bool isKeyGrabbed;

    public GameObject[] keys, biscuits, potions, doors;
    public GameObject keyEffect, biscuitEffect, potionEffect, doorEffect;

    private void MakeKeyShine() {
        Debug.Log("Key shining");
        CreateEffectForObjects(keys, keyEffect);
    }

    private void MakeBiscuitShine() {
        Debug.Log("Biscuit shining");
        CreateEffectForObjects(biscuits, biscuitEffect);
    }

    private void MakePotionShine()
    {
        Debug.Log("Potion shining");
        CreateEffectForObjects(potions, potionEffect);
    }

    private void MakeDoorShine()
    {
        Debug.Log("Door shining");
        CreateEffectForObjects(doors, doorEffect);
    }

    private void CreateEffectForObjects(GameObject[] objects, GameObject fromModel)
    {
        foreach (GameObject o in objects)
        {
            // add effect to object
            CreateEffect(fromModel, o.transform);
        }
    }

    private GameObject CreateEffect(GameObject fromModel, Transform parentTransform)
    {
        GameObject newEffect = Instantiate(fromModel, parentTransform);
        newEffect.transform.localPosition = Vector3.zero;
        return newEffect;
    }

    private void StopShining()
    {
        Debug.Log("Stop shining");
        GameObject[] effects = GameObject.FindGameObjectsWithTag("trip_effect");
        // destroy all effects
        foreach (GameObject e in effects) Destroy(e);
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
                    if(isKeyGrabbed) {
                        MakePotionShine(); // bisogna diventare piccoli per prendere la chiave
                    } else {
                        switch (keyRequiredSize)
                        {
                            case PlayerState.big: MakeBiscuitShine(); break; // bisogna diventare grandi per prendere la chiave
                            case PlayerState.medium: MakeKeyShine(); break; // si può prendere la chiave
                            case PlayerState.small: MakePotionShine(); break; // bisogna diventare piccoli per prendere la chiave
                        }
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
        // registrazione agli eventi
        EventManager.OnKeyNeedState += UpdateKeyPosition;
        EventManager.PostBecomeBigger += delegate () { NextSize(true); };
        EventManager.PostBecomeSmaller += delegate () { NextSize(false); };
        EventManager.OnKeyGrabbed += KeyGrabbed;

        // setup guide
        keyRequiredSize = PlayerState.big;
        playerSize = PlayerState.medium;
        isKeyGrabbed = false;

        TryMoveOn();
	}

    private void OnDestroy()
    {
        // rimozione registrazione
        EventManager.OnKeyNeedState -= UpdateKeyPosition;
        EventManager.PostBecomeBigger -= delegate () { NextSize(true); };
        EventManager.PostBecomeSmaller -= delegate () { NextSize(false); };
        EventManager.OnKeyGrabbed -= KeyGrabbed;
    }
}
