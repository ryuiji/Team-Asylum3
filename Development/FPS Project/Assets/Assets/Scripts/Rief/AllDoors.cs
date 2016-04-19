using UnityEngine;
using System.Collections;

public class AllDoors : MonoBehaviour {

    public GameObject[] allDoors;

	void Start () {
        allDoors = GameObject.FindGameObjectsWithTag("Deur");
	}
}
