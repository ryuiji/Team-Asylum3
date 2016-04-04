using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour {
	public Light light;
	// Use this for initialization
	void Start () {
	StartCoroutine("Muzzle");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator Muzzle()
	{
		light.enabled=true;
		yield return new WaitForSeconds(0.1f);
		light.enabled=false;
		Destroy(this.gameObject);
	}
}
