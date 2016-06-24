using UnityEngine;
using System.Collections;

public class ElectricSwitch : MonoBehaviour 
{
	public AudioClip switchOn, powerOn, powerDown, genOn, genLoop, spark;
	public Animator anim;
	public AudioSource audio;
	public AudioSource generatorAudio;
	public Generator generator;
	public ParticleSystem particle;
	public GameObject[] lights;
	public bool active;

	public void Start()
	{
		lights = GameObject.FindGameObjectsWithTag("GeneratorLight");
	}

	public IEnumerator Activate()
	{
		if(active==false)
		{
			audio.Stop();
			active=true;
			for(int i = 0; i<lights.Length; i++)
			{
				lights[i].GetComponent<GeneratorLight>().StartCoroutine("PowerOn");
				lights[i].GetComponent<GeneratorLight>().StopCoroutine("PowerDown");
			}
			audio.PlayOneShot(spark);
			audio.PlayOneShot(switchOn);
			anim.SetTrigger("Activate");
			particle.Play();
			generatorAudio.PlayOneShot(powerOn);
			generatorAudio.PlayOneShot(genOn);
			generatorAudio.Play();
			generatorAudio.loop=true;
			generator.enabled=true;
			yield return new WaitForSeconds(0.5f);
			audio.PlayOneShot(spark);
			//opensDoor
		}
		else
		{
			anim.SetTrigger("Deactivate");
			active=false;
			audio.Stop();
			generatorAudio.loop=false;
			generator.StopCoroutine("Sparks");
			generator.enabled=false;
			audio.PlayOneShot(spark);
			audio.PlayOneShot(switchOn);
			particle.Play();
			for(int i = 0; i<lights.Length; i++)
			{
				lights[i].GetComponent<GeneratorLight>().StopCoroutine("PowerOn");
				lights[i].GetComponent<GeneratorLight>().StartCoroutine("PowerDown");
			}
			audio.PlayOneShot(powerDown);
			yield return null;
		}

	}
}
