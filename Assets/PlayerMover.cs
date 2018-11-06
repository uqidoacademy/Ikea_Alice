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
        var camera = GameObject.FindGameObjectWithTag("FollowHead");
        var fader = camera.GetComponent<FadeScreen>();
        fader.FadeEffectNow();
        MoveToDestination(teleportLocationRoom.transform, 1);


    }

    private void MoveToDestination(Transform destination, float waitTime)
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(waitTime);
        seq.Append(transform.DOMove(destination.position, 0));
        seq.Append(transform.DORotate(destination.rotation.eulerAngles, 0));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
