using UnityEngine;
using System.Collections;

public class GeneratorLight : MonoBehaviour {

	public Light light;
	public int flickerAmount;
	public float intensityToSet;

	void Start()
	{
		light=GetComponent<Light>();
	}
	public IEnumerator PowerOn()
	{
		light.intensity=2;
		yield return new WaitForSeconds(0.2f);
		for(int i =0; i<flickerAmount; i++)
		{
			light.intensity=0;
			yield return new WaitForSeconds(0.2f);
			light.intensity=intensityToSet;
		}
		light.enabled=true;
	}

	public IEnumerator PowerDown()
	{
		while(light.intensity>0)
		{
			light.intensity-=0.02f;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
