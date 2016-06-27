using UnityEngine;
using System.Collections;

public class SarahChaser : MonoBehaviour {

	public AudioClip screamSmiley, screamSarah;
	public Animator anim;
	public Transform sarah;
	public float speed;
	public bool active;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(active)
		{
			anim.SetBool("Detect Enemy",true);
			anim.SetBool("Run",true);
			sarah.position+=sarah.transform.right*Time.deltaTime*speed;
			transform.position = Vector3.MoveTowards(transform.position,sarah.position,speed*Time.deltaTime);
		}
		if(Input.GetButtonDown("Jump"))
		{
			GetComponent<AudioSource>().PlayOneShot(screamSmiley);
			GetComponent<AudioSource>().PlayOneShot(screamSarah);
			active=!active;
		}
		
	}
}
