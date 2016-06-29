using UnityEngine;
using System.Collections;

public class ElectricDoor : MonoBehaviour 
{
	public ElectricSwitch generator;
	public bool isOpen;
	public Animator anim1, anim2;
	private bool mayOpen =true;
	public AudioClip doorSound;
	// Use this for initialization
	void Start () 
	{

	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.B))
		{
			UseDoor();
		}
	
	}

	void UseDoor()
	{
		if(generator.active && mayOpen)
		{
			if(isOpen)
			{
				StartCoroutine(Close());
			}
			else if(!isOpen)
			{
				StartCoroutine(Open());
			}
			isOpen=!isOpen;
			GetComponent<AudioSource>().PlayOneShot(doorSound);
		}
	}


	IEnumerator Close()
	{
		mayOpen=false;
		anim1.SetTrigger("Close");
		anim2.SetTrigger("Close");
		yield return new WaitForSeconds(2f);
		mayOpen=true;
	}

	IEnumerator Open()
	{
		mayOpen=false;
		anim1.SetTrigger("Open");
		anim2.SetTrigger("Open");
		yield return new WaitForSeconds(2f);
		mayOpen=true;
	}
}
