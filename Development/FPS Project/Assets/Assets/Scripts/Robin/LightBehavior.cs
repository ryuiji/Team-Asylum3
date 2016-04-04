using UnityEngine;
using System.Collections;

public class LightBehavior : MonoBehaviour {
	public float flickerTime;

	void Start () {
		StartCoroutine(ChangeLight());
	}

	void Update () {
		flickerTime = Random.Range(0.1f, 1f);
	}

	public IEnumerator ChangeLight () {
		while(true) {
			yield return new WaitForSeconds(flickerTime);
			GetComponent<Light>().enabled = false;
			yield return new WaitForSeconds(flickerTime);
			GetComponent<Light>().enabled = true;
		}
	}
}
