using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyPartSpawn : MonoBehaviour {

    public GameObject keyPart;
    private int maxSpawn;
    public List<GameObject> keySpawns = new List<GameObject>();

    void Start () {
        
        InvokeRepeating("RandomKeySpawn", 0, 1);

    }
    void RandomKeySpawn() {


        while(maxSpawn < 3) {
            int spawnNum = Random.Range(0, keySpawns.Count);
            Instantiate(keyPart, keySpawns[spawnNum].transform.position, Quaternion.identity);
            keySpawns.RemoveAt(spawnNum);
            maxSpawn++;

        }
        Destroy(gameObject);
    }

    void Update() {

    }
}
