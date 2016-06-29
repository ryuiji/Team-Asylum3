using UnityEngine;
using System.Collections;

public class DoorSwitch : MonoBehaviour {
	public bool on;
	public ElectricDoor door;
	public ElectricSwitch gen;
	public Animator anim;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Use()
	{
		if(gen.active==true)
		{
			if(!on)
			{
				anim.SetTrigger("On");
				door.UseDoor();
			}
			else if(on)
			{
				anim.SetTrigger("Close");
				door.UseDoor();
			}
		}
	}
}
