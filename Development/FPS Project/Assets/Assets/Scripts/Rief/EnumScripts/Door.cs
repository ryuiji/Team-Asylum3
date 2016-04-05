using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public bool isOpen;
    public int roomID;
	
	public void Open () {
        GetComponent<Animator>().SetTrigger("DoorInteraction");
        isOpen = !isOpen;
	}
}
