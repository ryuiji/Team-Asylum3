using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour {
    public GameObject player;
    PlayerStats playerHP;

    public void Start() {
        playerHP = player.GetComponent<PlayerStats>();
    }
    public void TrueBottle() {
        playerHP.maxHp += 10;
    }

    public void FalseBottle() {
        playerHP.hp -= playerHP.maxHp;
    }
}
