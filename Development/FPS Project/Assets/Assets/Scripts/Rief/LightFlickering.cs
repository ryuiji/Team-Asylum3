using UnityEngine;
using System.Collections;

public class LightFlickering : MonoBehaviour {

    public Light lightF;
    public float minWait;
    public float maxWait;

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
