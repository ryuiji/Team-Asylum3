﻿using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {

    public GameObject player;
    PlayerStats playerKeys;
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerKeys = player.GetComponent<PlayerStats>();
    }

	public void KeyFound () {
        
        if(playerKeys.keyFound.Length != playerKeys.keyCount) {
            playerKeys.keyFound[playerKeys.keyCount] = true;
            playerKeys.keyCount++;
            Destroy(gameObject);
            playerKeys.keySpawn.GetComponent<KeyPartSpawn>().maxSpawn--;
        }
    }
}
