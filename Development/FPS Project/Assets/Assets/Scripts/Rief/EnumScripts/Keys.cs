using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {

    public GameObject player;
    PlayerStats playerKeys;
    public int keyCount;
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerKeys = player.GetComponent<PlayerStats>();
    }

	public void KeyFound () {
        
        if(playerKeys.keyFound.Length != keyCount) {
            playerKeys.keyFound[keyCount] = true;
            keyCount++;

        }
    }
    public void Update() {
        print(keyCount);
    }
}
