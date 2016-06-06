using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;
using System.Collections;

public class Hallicunation : MonoBehaviour
{
    public AudioClip audioBang;
    public AudioSource bangSource;
    public AudioClip hallicunation1ScreamSound;
    public AudioClip hallicunationPantSound;
    public AudioSource audioSourceHall1;
    public CanvasGroup blackOut;
    public CanvasGroup groupOne;
    public QuickieController controller;
    public Gunmanage gunManager;
    public Vortex vortex;
    public NoiseAndGrain noise;
    public GameObject door;
    public ParticleSystem doorParticle;
    

    public void StartHall()
    {
        StartCoroutine("Blackout", blackOut);
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

    public IEnumerator Blackout(CanvasGroup canvasGroup)
    {
        vortex.enabled=true;
        noise.enabled=true;
        gunManager.enabled=false;
        audioSourceHall1.PlayOneShot(hallicunationPantSound);
        controller.mouseSpeedX = 60f;
        controller.mouseSpeedY = 60f;
        controller.moveSpeed = 2f;
        canvasGroup.alpha = 1;
        while (blackOut.alpha > 0f)
        {
            FadeImageOut(blackOut, 1f);
            yield return new WaitForSeconds(0.01f);
        }
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
        while(vortex.radius.x>0)
        {
            noise.intensityMultiplier-=40*Time.deltaTime;
            vortex.radius.x-=1f*Time.deltaTime;
            if(noise.intensityMultiplier<0)
            {
                noise.intensityMultiplier=0;
            }
            yield return new WaitForSeconds(0.1f);
        }
        noise.enabled=false;
        vortex.enabled=false;
    }
}
