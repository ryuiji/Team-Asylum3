using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class smileyDeath : MonoBehaviour {

	public ragdollController03 RagScript;

    GameObject Head;
	GameObject Mouth;
	GameObject HairBack;
	GameObject HairLeft;
	GameObject HairRight;

	GameObject ArmL;
	GameObject ShoulderL;
	GameObject ArmPitL;

	GameObject ArmR;
	GameObject ShoulderR;
	GameObject ArmPitR;

	GameObject Back;
	GameObject BackLshirt;
	GameObject BackRshirt;

	GameObject BackLow;
	GameObject BackLowShirt;

	GameObject Pelvis;
	GameObject HipL;
	GameObject LovehandlesL;
	GameObject HipR;
	GameObject LovehandlesR;

	GameObject LegL;
	GameObject AssL;
	GameObject FrontThighL;
    GameObject InnerThighL;

	GameObject LegR;
	GameObject AssR;
	GameObject FrontThighR;
	GameObject InnerThighR;

	public bool ActivateDeath;


	// Use this for initialization


	void Start () 
		{

		RagScript = GetComponentInChildren<ragdollController03> ();

		Head = transform.Find ("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Spine2/Bip001 Spine3/Bip001 Neck/Bip001 Head").gameObject;
		Mouth = transform.Find ("AttaachHead").gameObject;
		HairBack = transform.Find ("Bip_BackHair01").gameObject;
		HairLeft = transform.Find ("Bip_LHair01").gameObject;
		HairRight = transform.Find ("Bip_RHair01").gameObject;

		ArmL = transform.Find ("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Spine2/Bip001 Spine3/Bip001 Neck/Bip001 L Clavicle/Bip001 L UpperArm").gameObject;
		ShoulderL = transform.Find ("Bip ShoulderL01").gameObject;
		ArmPitL = transform.Find ("Bip_ArmPit_L01").gameObject;

		ArmR = transform.Find ("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Spine2/Bip001 Spine3/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm").gameObject;
		ShoulderR = transform.Find ("Bip ShoulderR01").gameObject;
		ArmPitR = transform.Find ("Bip_ArmPit_R01").gameObject;

		Back = transform.Find ("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Spine2/Bip001 Spine3").gameObject;
		BackLshirt = transform.Find ("Bip_Back_L01").gameObject;
		BackRshirt = transform.Find ("Bip_Back_R01").gameObject;

		BackLow = transform.Find ("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1").gameObject;
		BackLowShirt = transform.Find ("Bip_BackLow01").gameObject;

		Pelvis = transform.Find ("Bip001/Bip001 Pelvis").gameObject;
		HipL = transform.Find ("Bip_HipL01").gameObject;
		LovehandlesL = transform.Find ("BipFuck_L01").gameObject;
		HipR = transform.Find ("Bip_HipR01").gameObject;
		LovehandlesR = transform.Find ("BipFuck_R01").gameObject;

		LegL = transform.Find ("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 L Thigh").gameObject;
		AssL = transform.Find ("Bip Ass_L").gameObject;
		FrontThighL = transform.Find ("Bip FrontThigh_L01").gameObject;
		InnerThighL = transform.Find ("Bip_InnerThigh_L01").gameObject;

		LegR = transform.Find ("Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 R Thigh").gameObject;
		AssR = transform.Find ("Bip Ass_R").gameObject;
		FrontThighR = transform.Find ("Bip FrontThigh_R01").gameObject;
		InnerThighR = transform.Find ("Bip_InnerThigh_R01").gameObject;
		}

	void SetParent()
	{
			Mouth.transform.parent = Head.transform;
			HairBack.transform.parent = Head.transform;
			HairLeft.transform.parent = Head.transform;
			HairRight.transform.parent = Head.transform;

			ShoulderL.transform.parent = ArmL.transform;
			ArmPitL.transform.parent = ArmL.transform;

			ShoulderR.transform.parent = ArmR.transform;
			ArmPitR.transform.parent = ArmR.transform;

			BackLshirt.transform.parent = Back.transform;
			BackRshirt.transform.parent = Back.transform;
			BackLowShirt.transform.parent = BackLow.transform;

			HipL.transform.parent = Pelvis.transform;
			LovehandlesL.transform.parent = Pelvis.transform;
			HipR.transform.parent = Pelvis.transform;
			LovehandlesR.transform.parent = Pelvis.transform;

			AssL.transform.parent = LegL.transform;
			FrontThighL.transform.parent = LegL.transform;
			InnerThighL.transform.parent = LegL.transform;

			AssR.transform.parent = LegR.transform;
			FrontThighR.transform.parent = LegR.transform;
			InnerThighR.transform.parent = LegR.transform;
	}


	void Update () 
	{
		if (ActivateDeath == true) 
		{
			RagScript.isDead = true;
			SetParent ();
			ActivateDeath = false;

		}
	}
/*	void LateUpdate ()
	{
		if (ActivateDeath)
		{

		}
	}
*/
}