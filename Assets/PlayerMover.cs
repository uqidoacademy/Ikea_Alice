using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

    public GameObject teleportLocationRoom;
    public GameObject teleportLocationSmall;

    public void goToSmallSpawn()
    {
        transform.position = teleportLocationSmall.transform.position;
    }

    public void goToRoomSpawn()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FadeScreen>().FadeEffectNow();
        transform.DOMove(teleportLocationRoom.transform.position, 4);
        transform.DORotate(teleportLocationRoom.transform.rotation.eulerAngles, 4, RotateMode.Fast);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
