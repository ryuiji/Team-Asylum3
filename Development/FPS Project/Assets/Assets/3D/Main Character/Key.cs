using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	public Animator anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.W))
		{
			print("Input");
			anim.SetBool("AK47 Equip", false);
			anim.SetBool("Hgun Equip", true);
		}
	if(Input.GetKeyDown(KeyCode.E))
		{
			print("Input");
			anim.SetBool("Hgun Equip", false);
			anim.SetBool("AK47 Equip", true);
		}
	}
}
