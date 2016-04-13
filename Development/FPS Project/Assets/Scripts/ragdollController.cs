using UnityEngine;
using System.Collections;

public class ragdollController : MonoBehaviour {

	public Component[] bones;
	public Animator anim;
	public bool isDead;



	void Start () {

		bones = gameObject.GetComponentsInChildren<Rigidbody> (); 
		anim = GetComponent<Animator> ();


	}
	void Update ()

	{
		if (isDead)
			killRagdoll ();

	}


	void killRagdoll () 
	{
		foreach (Rigidbody ragdoll in bones)
		{
			ragdoll.isKinematic = false;
		}

		anim.enabled = false;
	}
}