using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class AudioManager : MonoBehaviour
{
    public List<AudioClip> sounds = new List<AudioClip>();
    public List<AudioClip> sounds2 = new List<AudioClip>();
    

    [Header("")]
    public float minWait,maxWait;
    public AudioSource[] sources;
    void Start()
    {
        StartCoroutine("AudioChain");
    }

    IEnumerator AudioChain()
    {
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        int index = Random.Range(0, sounds.Count);
        int sourceIndex = Random.Range(0, sources.Length);
        sources[sourceIndex].PlayOneShot(sounds[index]);
        sounds2.Add(sounds[index]);
        sounds.RemoveAt(index);
        if (sounds.Count == 0)
        {
            StartCoroutine("AudioChain2");
            yield break;
        }
        else
        {
            StartCoroutine("AudioChain");
        }
    }

    IEnumerator AudioChain2()
    {
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        int index = Random.Range(0, sounds2.Count);
        int sourceIndex = Random.Range(0, sources.Length);
        sources[sourceIndex].PlayOneShot(sounds[index]);
        sounds.Add(sounds2[index]);
        sounds2.RemoveAt(index);
        if (sounds2.Count == 0)
        {
            StartCoroutine("AudioChain");
            yield break;
        }
        else
        {
            StartCoroutine("AudioChain2");
        }
    }
}
