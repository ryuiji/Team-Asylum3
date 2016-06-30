using UnityEngine;
using System.Collections;

public class RedFlickerLight : MonoBehaviour 
{
	public Light light;
	public Material mat;
	public Color onColor,offColor;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine("LightFlicker");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	IEnumerator LightFlicker()
	{
		light.intensity=0f;
		mat.SetColor ("_EmissionColor", offColor);	
		yield return new WaitForSeconds(1f);
		light.intensity=1.5f;
		mat.SetColor ("_EmissionColor", onColor);
		yield return new WaitForSeconds(1f);
		StartCoroutine("LightFlicker");
	}
}
