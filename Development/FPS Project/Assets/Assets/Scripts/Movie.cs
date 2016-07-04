using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movie : MonoBehaviour {
    public MovieTexture movieTexture;
    private AudioSource audioSource;
    public RawImage raw;
	// Use this for initialization

    

    void Awake()
    {
        if(movieTexture!=null)
        {
            audioSource=GetComponent<AudioSource>();
            audioSource.clip=movieTexture.audioClip;
            audioSource.Play();
            movieTexture = (MovieTexture) raw.mainTexture;
            movieTexture.Play();
        }
        StartCoroutine("MovieIE");
    }


    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator MovieIE()
    {
        yield return new WaitForSeconds(movieTexture.audioClip.length);
        Awake();
    }
}
