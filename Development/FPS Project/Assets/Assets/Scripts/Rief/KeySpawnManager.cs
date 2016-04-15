using UnityEngine;
using System.Collections;

public class KeySpawnManager : MonoBehaviour {

    public GameObject spawnLocKeysList;
	void Start () {
        GameObject tempObject = Instantiate(spawnLocKeysList, transform.position, Quaternion.identity) as GameObject;

    }
	

	void Update () {
	
	}
}
