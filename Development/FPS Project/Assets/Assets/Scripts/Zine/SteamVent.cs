using UnityEngine;
using System.Collections;

public class SteamVent : MonoBehaviour
{
    public float minimumDelay;
    public float maximumDelay;
    public AudioSource steamSource;
    public AudioClip steamSound;
    public ParticleSystem particle;
    private float releaseLength;
    // Use this for initialization
    void Start()
    {
        releaseLength=particle.duration;
        StartCoroutine("Release");
    }

    // Update is called once per frame
    IEnumerator Release()
    {
        yield return new WaitForSeconds(Random.Range(minimumDelay,maximumDelay));
        GetComponent<Collider>().enabled=true;
        particle.emissionRate=10;
        steamSource.PlayOneShot(steamSound);
        particle.Play();
        StartCoroutine("LessenSteam");
        yield return new WaitForSeconds(releaseLength);
        GetComponent<Collider>().enabled=false;
        particle.Stop();
        steamSource.Stop();
        StartCoroutine("Release");
    }

    IEnumerator LessenSteam()
    {
        while(particle.emissionRate>0)
        {
            particle.emissionRate-=1;
            yield return new WaitForSeconds(0.45f);
        }
    }
}
