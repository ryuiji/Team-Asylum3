﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyPartSpawn : MonoBehaviour {

    public GameObject keyPart;
    public int maxSpawn;
    public List<GameObject> keySpawns = new List<GameObject>();

    void Start () {
        RandomKeySpawn();
    }
    public void RandomKeySpawn() {


        while(maxSpawn < 3) {
            int spawnNum = Random.Range(0, keySpawns.Count);
            Instantiate(keyPart, keySpawns[spawnNum].transform.position, Quaternion.identity);
            keySpawns[spawnNum].SetActive(false);
            maxSpawn++;

        }
    }
}
