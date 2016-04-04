using UnityEngine;
using System.Collections;

public class LightFlickering : MonoBehaviour {

    public Light lightF;
    private float minWait = 0.1f;
    private float maxWait = 1f;

	void Start () {
        lightF.enabled = false;
        StartCoroutine(LightFlicker());

    }


    IEnumerator LightFlicker() {
        lightF.enabled = true;
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        lightF.enabled = false;
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        StartCoroutine(LightFlicker());
    }
}
