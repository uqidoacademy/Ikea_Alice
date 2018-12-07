using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartTimeline : MonoBehaviour {

	private PlayableDirector timeline;

	// Use this for initialization
	void Start () {
		timeline = GetComponent<PlayableDirector>();
	}
	
	public void StartTimelineNow(){
		timeline.Play();
	}
}
