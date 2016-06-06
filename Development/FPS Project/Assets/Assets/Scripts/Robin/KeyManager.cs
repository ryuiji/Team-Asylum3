using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyManager : MonoBehaviour {

	public List<GameObject> spawnPoints = new List<GameObject>();
	public GameObject key;
	public int maxKeySpawn;
	public int currentKeys;
	private int randomNumber;

	void Start () {
		StartSpawning();
	}

	void StartSpawning () {
		for(int i = 0; i < maxKeySpawn; i++) {
			randomNumber = Random.Range(0, spawnPoints.Count);
			Instantiate(key, spawnPoints[randomNumber].transform.position, Quaternion.identity);
			spawnPoints.RemoveAt(randomNumber);
		}
	}

	public void AddOneKey () {
		currentKeys++;
		if(currentKeys == 3) {
			OpenDoor();
			HudPopup();
		}
	}

	void OpenDoor () {
		GetComponent<Animator>().SetBool("OpenDoor", true);
	}

	void HudPopup () {
		//
	}
}
