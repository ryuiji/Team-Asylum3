﻿using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	
	public void Open () {
        GetComponent<Animator>().SetTrigger("DoorInteraction");
	}
}
