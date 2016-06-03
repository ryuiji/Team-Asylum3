using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject key;
	public int maxKeySpawn;
	public int currentKeys;

	void Start () {
		StartSpawning();
	}

	void StartSpawning () {
		for(int i = 0; i < maxKeySpawn; i++) {
			Instantiate(key, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
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
