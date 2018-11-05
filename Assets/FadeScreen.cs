using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour {

	public GameObject quadToFade;

	public GameObject teleportLocationRoom;
	public GameObject teleportLocationSmall;

	public void FadeScreenNow () {
		transform.position = teleportLocationRoom.transform.position;
        transform.rotation = teleportLocationRoom.transform.rotation;
		//GameObject quad = Instantiate(quadToFade);
		//quad.transform.parent = transform;
		//quad.transform.localPosition = new Vector3(0,0,1);
		//quad.transform.localRotation = Quaternion.identity;
		//quad.transform.localScale = new Vector3(2,2,2);
		//StartCoroutine (Lerp_MeshRenderer_Color (quad, 30f,new Color(0f,0f,0f,0f),new Color(0f,0f,0f,1f)));
	}

	public void GoToSmallSpawn(){
		transform.position = teleportLocationSmall.transform.position;
	}

	private IEnumerator Lerp_MeshRenderer_Color (GameObject gameOb, float lerpDuration, Color startLerp, Color targetLerp) {
		MeshRenderer target_MeshRender = gameOb.GetComponent<MeshRenderer>();
		target_MeshRender.material.color = startLerp;
		/* float lerpStart_Time = Time.time;
		float lerpProgress;
		bool lerping = true;
		while (lerping) {
			yield return new WaitForEndOfFrame ();
			lerpProgress = Time.time - lerpStart_Time;
			if (target_MeshRender != null) {
				target_MeshRender.material.color = Color.Lerp (startLerp, targetLerp, lerpProgress / lerpDuration);
			} else {
				lerping = false;
			}

			if (lerpProgress >= lerpDuration) {
				lerping = false;
			}
		}*/
		yield break;
	}
}