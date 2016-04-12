using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    public float hp;
    public float maxHp;
    public float healthReg;
    public float sanity;
    public float maxSanity;
    public float sanityReg;
    public GameObject respawnLoc;
    public GameObject keySpawn;
    public int keyCount;
    public bool[] keyFound;
    private int keyToUnlock = 3;


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
        hp = maxHp;
        sanity = maxSanity;
        transform.position = respawnLoc.transform.position;
        for (int i = 0; i < keyToUnlock; i++) {
            keyFound[i] = false;
            keyCount = 0;
            keySpawn.GetComponent<KeyPartSpawn>().RandomKeySpawn();
        }
    }
}
