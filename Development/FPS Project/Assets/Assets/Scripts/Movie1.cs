using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movie1 : MonoBehaviour {
    public MovieTexture movieTexture;
    private AudioSource audioSource;
    public CanvasGroup fade;
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
        StartCoroutine("FadeIn");
        yield return new WaitForSeconds(movieTexture.audioClip.length-1);
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeIn()
    {
        while (fade.alpha > 0f)
        {
            FadeImageOut(fade, 1f);
            yield return new WaitForSeconds(0.01f);
        }

    }

    IEnumerator FadeOut()
    {
        while (fade.alpha < 1f)
        {
            FadeImageIn(fade, 1f);
            yield return new WaitForSeconds(0.01f);
        }

    }



    //void OnGUI()
    //{
    //    if(movieTexture!=null && movieTexture.isPlaying)
    //    {
    //        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),movieTexture,ScaleMode.StretchToFill);
    //    }

    //}

    public void FadeImageOut(CanvasGroup image, float amount)
    {
        image.alpha -= amount * Time.deltaTime;
        if (image.alpha < 0)
        {
            image.alpha = 0;
        }
    }

    public void FadeImageIn(CanvasGroup image, float amount)
    {
        image.alpha += amount * Time.deltaTime;
        if (image.alpha > 1)
        {
            image.alpha = 1;
        }
    }



}
