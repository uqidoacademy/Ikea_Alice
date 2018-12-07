using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlikerIntensity : MonoBehaviour {
    public GameObject SmallLights;
	public GameObject BigLights;
    public float timer = 0.1f;
	public float maxIntensity = 1.6f;
	public float minIntensity = 1.5f;

	private float currentIntensity;
 
    void Start()
    {
        StartCoroutine(FlickeringLight());
    }
 
    IEnumerator FlickeringLight()
    {
        currentIntensity = Random.RandomRange(minIntensity, maxIntensity);
		SmallLights.GetComponent<Light>().intensity = currentIntensity;
		BigLights.GetComponent<Light>().intensity = currentIntensity;
       
        yield return new WaitForSeconds(timer);
        StartCoroutine(FlickeringLight());
    }
}

