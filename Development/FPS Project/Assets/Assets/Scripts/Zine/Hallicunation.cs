using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hallicunation : MonoBehaviour
{
    public Sprite[] hallicunation1Images;
    public AudioClip hallicunation1ScreamSound, hallicunationPantSound;
    public CanvasGroup hallicunation1CanvasGroup;
    public AudioSource audioSourceHall1;
    public CanvasGroup blackOut;
    public PlayerController controller;
    public Gunmanage gunManager;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("HallicunationOne", hallicunation1CanvasGroup);
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



    public IEnumerator HallicunationOne(CanvasGroup canvasgroup)
    {
        for(int i = 0; i<5; i++)
        {
            while (canvasgroup.alpha < 0.1f)
            {
                FadeImageIn(canvasgroup, 0.25F);
                yield return new WaitForSeconds(0.01f);
            }
            while (canvasgroup.alpha > 0)
            {
                FadeImageOut(canvasgroup, 0.25F);
                yield return new WaitForSeconds(0.01f);
            }
        }
        gunManager.enabled = false;
        audioSourceHall1.PlayOneShot(hallicunation1ScreamSound);
        while (canvasgroup.alpha < 1f)
        {
            canvasgroup.transform.localScale+=new Vector3(0.5f,0.5f,0.5f);
            FadeImageIn(canvasgroup, 1);
            FadeImageIn(blackOut, 2);
            yield return new WaitForSeconds(0.01f);
        }

        GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(1f);
        StartCoroutine("Blackout",canvasgroup);
        
    }

    public IEnumerator Blackout(CanvasGroup canvasGroup)
    {
        gunManager.enabled=false;
        audioSourceHall1.PlayOneShot(hallicunationPantSound);
        controller.rotateSpeed = 1f;
        controller.moveSpeed = 1f;
        controller.runSpeed = 2f;
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
        controller.rotateSpeed = 4f;
        controller.moveSpeed = 4f;
        controller.runSpeed = 8f;
        gunManager.enabled = true;
    }
}
