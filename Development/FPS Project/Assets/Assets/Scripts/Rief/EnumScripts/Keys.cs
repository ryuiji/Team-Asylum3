using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {

    public GameObject player;
    PlayerStats playerKeys;
    KeyPartSpawn keySpawnP;
    public GameObject keyPartSpawn;
    public int spawnLocNum;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerKeys = player.GetComponent<PlayerStats>();
        keyPartSpawn = GameObject.Find("SpawnPointsKey");
    }

	public void KeyFound () {
        keySpawnP = keyPartSpawn.GetComponent<KeyPartSpawn>();
        if (playerKeys.keyFound.Length != playerKeys.keyCount) {
            playerKeys.keyFound[playerKeys.keyCount] = true;
            keySpawnP.keySpawns[spawnLocNum].GetComponent<KeyBoolean>().canSpawn = true;
            playerKeys.keyCount++;
            }
            Destroy(gameObject);
            playerKeys.keySpawn.GetComponent<KeyPartSpawn>().spawned--;
        }
    }

