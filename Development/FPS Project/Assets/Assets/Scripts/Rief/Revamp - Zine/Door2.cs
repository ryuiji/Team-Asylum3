using UnityEngine;
using System.Collections;

public class Door2 : MonoBehaviour
{
    public bool open;
    public Animator door;
    public AudioClip openDoor, closeDoor, creakingDoor;
    public AudioSource audio;
    public bool checkIfPlaying;

    void Start()
    {
        door=GetComponent<Animator>();
        if(open)
        {
            StartDoor();
        }
        if(!open)
        {
        	StartDoor();
        }
    }

    IEnumerator Door()
    {
        if(open)
        {
            audio.PlayOneShot(openDoor);
            yield return new WaitForSeconds(0.33f);
            audio.PlayOneShot(creakingDoor);
        }
        else if(!open)
        {
            yield return new WaitForSeconds(0.25f);
            audio.PlayOneShot(creakingDoor);
            yield return new WaitForSeconds(creakingDoor.length);
            audio.PlayOneShot(closeDoor);
        }
    }



    public void UseDoor()
    {
        if(checkIfPlaying==false)
        {
            door.SetBool("OpenClose",open);
            door.SetTrigger("Door");
            StartCoroutine("Door");
            StartCoroutine("DoorWait");
            open = !open;
        }
    }


    public void StartDoor()
    {
        if(checkIfPlaying==false)
        {
            door.SetBool("OpenClose",open);
            door.SetTrigger("Door");
            open = !open;
        }
    }

    IEnumerator DoorWait()
    {
        checkIfPlaying=true;
        yield return new WaitForSeconds(0.5f);
        checkIfPlaying=false;
    }
}
