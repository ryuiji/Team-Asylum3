using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public GameObject respawnLoc;
    public GameObject keySpawn;
    public GameObject doorManager;
    public float hp;
    public float maxHp;
    public float healthReg;
    public float sanity;
    public float maxSanity;
    public float sanityReg;
    public int keyCount;
    public int keyToUnlock = 3;
    public bool puzzle1Complete;


    void Start () {
        hp = maxHp;
        sanity = maxSanity;
	}

    void Update() {
        CheckHealth();
        CheckSanity();
    }

    void HealthRegen() {
        if (hp >1 ) {
            hp += healthReg * Time.deltaTime;
        }
    }

    void SanityRegen() {
        sanity += sanityReg * Time.deltaTime;
    }

	void CheckHealth () {
	    if(hp >= maxHp) {
            hp = maxHp;
        }
        if(hp < maxHp) {
            HealthRegen();
        }
        if(hp <= 0) {
            //speel death animatie af
            Die();
        }
	}

    void CheckSanity() {
        if(sanity >= maxSanity) {
            sanity = maxSanity;
        }
        if(sanity < maxSanity) {
            SanityRegen();
        }
        if(sanity <= 0) {
            //speel suicide animatie af
            Die();
            
        }
    }
    void Die() {
        //wapens(start met pistol)
        //deuren dicht die dicht horen
        //ammo van pistol
        //flashlight uit
        //enemy spawn
        AllDoors doorFix;
        doorFix = doorManager.GetComponent<AllDoors>();
        for (int i = 0; i < doorFix.allDoors.Length; i++) {
            doorFix.allDoors[i].GetComponent<Door>().isOpen = false;
        }
        puzzle1Complete = false;
        hp = maxHp;
        sanity = maxSanity;
        transform.position = respawnLoc.transform.position;
        transform.rotation = respawnLoc.transform.rotation;
        keyCount = 0;
        keySpawn.GetComponent<KeyPartSpawn>().RandomKeySpawn();
        }
}
