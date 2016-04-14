using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyPartSpawn : MonoBehaviour {

    public GameObject keyPart;
    public int maxSpawn;
    public List<GameObject> keySpawns = new List<GameObject>();
    public GameObject[] spawnLocation;

    void Start () {
        RandomKeySpawn();
    }
    public void RandomKeySpawn() {
        while(maxSpawn < 3) {
            int spawnNum = Random.Range(0, keySpawns.Count);
            if (keySpawns[spawnNum].GetComponent<KeyBoolean>().canSpawn == true) {
                Instantiate(keyPart, keySpawns[spawnNum].transform.position, Quaternion.identity);
                keySpawns[spawnNum].GetComponent<KeyBoolean>().canSpawn = false;
                SafeLocation(maxSpawn, spawnNum);
                maxSpawn++;
            }
        }
    }

    public void SafeLocation (int maxSpawn, int spawnNum) {
        spawnLocation[maxSpawn] = keySpawns[spawnNum];
    }
}
