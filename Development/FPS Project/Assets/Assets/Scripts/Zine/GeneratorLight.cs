using UnityEngine;
using System.Collections;

public class GeneratorLight : MonoBehaviour {

	public Light light;
	public int flickerAmount;

	void Start()
	{
		light=GetComponent<Light>();
	}
	public IEnumerator PowerOn()
	{
		light.intensity=2;
		light.enabled=true;
		for(int i =0; i<flickerAmount; i++)
		{
			yield return new WaitForSeconds(0.2f);
			light.enabled=false;
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
