using UnityEngine;
using System.Collections;

public class AccesScript : MonoBehaviour {

	public GameObject Arms;
	public ragdollController ArmsScript;

	public GameObject Body;
	public ragdollController BodyScript;

	public GameObject Camura;
	public GameObject Head;


	// Use this for initialization
	void Start () 
		{

		Arms = GameObject.Find ("MC_Arms");
		ArmsScript = Arms.GetComponent<ragdollController>();

		Arms = GameObject.Find ("MC_Arms");
		ArmsScript = Arms.GetComponent<ragdollController> ();

		Body = GameObject.Find ("MainCharacter");
		BodyScript = Body.GetComponent<ragdollController> ();

		Body = GameObject.Find ("MainCharacter");
		BodyScript = Body.GetComponent<ragdollController> ();

		Camura = GameObject.Find ("MainCamera01");
		Head = GameObject.Find ("MC_Head");
	
	}

	void DeathCam () {
		if (BodyScript.isDead == true) 
		{
			Camura.transform.parent = Head.transform;
		}

	}
	void Update () 
	{
		ArmsScript.isDead = true;
		BodyScript.isDead = true;
		DeathCam ();

	}
}
