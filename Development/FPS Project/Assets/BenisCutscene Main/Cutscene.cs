using UnityEngine;
using System.Collections;

public class Cutscene : MonoBehaviour
{
    public ParticleSystem particle;
    public Animator door1, door2, camera;
    public GameObject cameraObj, camPrefab;
    public RuntimeAnimatorController camAvatar;
    public Transform cameraPos1, cameraPos2, cameraPos3, cameraPos4;
    public AudioSource audioPig, audioChain, audioWoman, backGroundAudio;
    public AudioClip womanBeg,womanNo,womanScream, chainSawIdle,chainSawAttack, pigBenisOink, pigBenisOink2, pigBenisOink3, backGrounMusic, doorOpen;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("Cutscene1");
        backGroundAudio.PlayOneShot(backGrounMusic);
        audioChain.PlayOneShot(chainSawIdle);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Cutscene1()
    {
        yield return new WaitForSeconds(1f);
        backGroundAudio.PlayOneShot(doorOpen);
        door1.SetTrigger("Open");
        door2.SetTrigger("Open");
        yield return new WaitForSeconds(3f);
        audioPig.PlayOneShot(pigBenisOink);
        cameraObj.transform.position = cameraPos1.position;
        cameraObj.transform.rotation = cameraPos1.rotation;
        yield return new WaitForSeconds(2f);
        audioWoman.PlayOneShot(womanBeg);
        cameraObj.transform.position = cameraPos2.position;
        cameraObj.transform.rotation = cameraPos2.rotation;
        yield return new WaitForSeconds(2f);
        audioWoman.PlayOneShot(womanNo);
        cameraObj.transform.position = cameraPos3.position;
        cameraObj.transform.rotation = cameraPos3.rotation;
        yield return new WaitForSeconds(2f);
        audioWoman.PlayOneShot(womanScream);
        camera = cameraObj.AddComponent<Animator>();
        camera.runtimeAnimatorController=camAvatar;
        audioChain.PlayOneShot(chainSawAttack);
        camera.SetBool("Shake", true);
        particle.Play();
        yield return new WaitForSeconds(2f);
        camera.SetBool("Shake", false);
        Destroy(camera);
        yield return new WaitForSeconds(1f);
        particle.Stop();
        audioPig.PlayOneShot(pigBenisOink2);
        cameraObj.transform.position = cameraPos4.position;
        cameraObj.transform.rotation = cameraPos4.rotation;
    }
}
