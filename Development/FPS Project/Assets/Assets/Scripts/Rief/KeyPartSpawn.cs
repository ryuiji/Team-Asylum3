using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyPartSpawn : MonoBehaviour {

    public GameObject keyPart;
    private int maxSpawn = 3;
    public int spawned;
    public List<GameObject> keySpawns = new List<GameObject>();

    void Start () {
        RandomKeySpawn();
    }
    public void RandomKeySpawn() {
        while(spawned < maxSpawn) {
            int spawnNum = Random.Range(0, keySpawns.Count);
            if (keySpawns[spawnNum].GetComponent<KeyBoolean>().canSpawn == true) {
                GameObject tempObject = Instantiate(keyPart, keySpawns[spawnNum].transform.position, Quaternion.identity) as GameObject;
                keySpawns[spawnNum].GetComponent<KeyBoolean>().canSpawn = false;
                tempObject.GetComponent<Keys>().spawnLocNum = spawnNum;
                spawned++;
            }
        }
    }
}
