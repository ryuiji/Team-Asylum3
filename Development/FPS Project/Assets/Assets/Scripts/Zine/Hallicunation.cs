using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hallicunation : MonoBehaviour
{
    public AudioClip hallicunationPantSound;
    public AudioSource audioSourceHall1;
    public CanvasGroup blackOut;
    public QuickieController controller;
    public Gunmanage gunManager;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("BlackOutOne");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeImageIn(CanvasGroup image, float amount)
    {
        image.alpha+=amount*Time.deltaTime;
        if(image.alpha>1)
        {
            image.alpha=1;
        }
    }

    public void FadeImageOut(CanvasGroup image, float amount)
    {
        image.alpha -= amount * Time.deltaTime;
        if (image.alpha < 0)
        {
            image.alpha = 0;
        }
    }



    public IEnumerator BlackOutOne()
    {
        yield return null;
        StartCoroutine("Blackout",blackOut);
        
    }

    public IEnumerator Blackout(CanvasGroup canvasGroup)
    {
        gunManager.enabled=false;
        audioSourceHall1.PlayOneShot(hallicunationPantSound);
        controller.mouseSpeedX = 60f;
        controller.mouseSpeedY = 60f;
        controller.moveSpeed = 2f;
        canvasGroup.alpha = 0;
        while (blackOut.alpha < 1f)
        {
            FadeImageIn(blackOut, 1f);
            yield return new WaitForSeconds(0.01f);
        }
        for (int i2 = 0; i2 < 2; i2++)
        {
            while (blackOut.alpha > 0.5f)
            {
                FadeImageOut(blackOut, 1f);
                yield return new WaitForSeconds(0.01f);
            }
            while (blackOut.alpha < 1f)
            {
                FadeImageIn(blackOut, 1f);
                yield return new WaitForSeconds(0.01f);
            }
        }
        while (blackOut.alpha > 0f)
        {
            FadeImageOut(blackOut, 1);
            yield return new WaitForSeconds(0.01f);
        }
        controller.mouseSpeedX = 180f;
        controller.mouseSpeedY = 360f;
        controller.moveSpeed = 5f;
        gunManager.enabled = true;
    }
}
