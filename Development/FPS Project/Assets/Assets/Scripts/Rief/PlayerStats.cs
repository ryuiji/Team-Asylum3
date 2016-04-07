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
            StartCoroutine(Die());
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
            StartCoroutine(Die());
            //speel suicide animatie af
        }
    }
    public IEnumerator Die() {
        Debug.Log("start loading");
        AsyncOperation loadLevel1 = SceneManager.LoadSceneAsync("Rief");
        Debug.Log("Busy loading");
        yield return loadLevel1;
    }
}
