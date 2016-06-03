using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour {

	public GameObject[] spawnPoints;
	private int maxSpawn;
	public GameObject key;
	private bool completeKey;

	void StartSpawning () {
		for(int i = 0; i < maxSpawn; i++) {
			Instantiate(key, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
		}
	}

	
}
