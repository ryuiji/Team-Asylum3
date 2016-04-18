using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccesScript : MonoBehaviour {

	public GameObject Arms;
	public ragdollController02 ArmsScript;

	public GameObject Body;
	public ragdollController BodyScript;

	public GameObject Camura;
	public GameObject Head;


	public bool ActivateDeath;


	// Use this for initialization


	void Start () 
		{
		Arms = GameObject.Find ("MC_Arms");
		ArmsScript = Arms.GetComponent<ragdollController02>();

		Arms = GameObject.Find ("MC_Arms");
		ArmsScript = Arms.GetComponent<ragdollController02> ();

		Body = GameObject.Find ("MainCharacter");
		BodyScript = Body.GetComponent<ragdollController> ();

		Body = GameObject.Find ("MainCharacter");
		BodyScript = Body.GetComponent<ragdollController> ();

		Camura = GameObject.Find ("MainCamera01");
		Head = GameObject.Find ("MC_Head");

		}

	void DeathCam () 
	{

		if (BodyScript.isDead == true) 
		{
			Camura.transform.parent = Head.transform;
		}

	}

	void HideWeapons ()
	{
		if (GameObject.Find ("Cleaver") != null)
		{
			GameObject.Find ("Cleaver").SetActive (false);
		}
		if (GameObject.Find ("AK47") != null)
		{
			GameObject.Find ("AK47").SetActive (false);
		}
		if (GameObject.Find ("HandGunFlashL") != null)
		{
			GameObject.Find ("HandGunFlashL").SetActive (false);
		}
		if (GameObject.Find ("ShotGun") != null)
		{
			GameObject.Find ("ShotGun").SetActive (false);
		}
	}
	void Update () 
	{
		if (ActivateDeath == true) 
		{
			ArmsScript.isDead = true;
			BodyScript.isDead = true;
			DeathCam ();
			HideWeapons ();
		}
	}
}
