using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	public ParticleSystem particle;
	public AudioSource audio;
	public AudioClip spark;
	// Use this for initialization
	void Start () {
	StartCoroutine("Sparks");
	}

	public IEnumerator Sparks()
	{
		audio.PlayOneShot(spark);
		particle.Play();
		yield return new WaitForSeconds(Random.Range(3,7));
		StartCoroutine("Sparks");
	}
	
}
