using UnityEngine;
using System.Collections;

public class Intercom : MonoBehaviour {

    public AudioClip soundToPlay;
    public AudioSource source;

    //source = AudioSource van waar je het geluid wilt afspelen
    //soundToPlay is welke sound je wilt afspelen

    void OnTriggerEnter(Collider soundPlay) {
        if(soundPlay.gameObject.tag == "Player") {
            source.PlayOneShot(soundToPlay);
            Destroy(gameObject, source.clip.length);
        }
    }
}
