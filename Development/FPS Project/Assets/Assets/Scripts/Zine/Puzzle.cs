using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour
{
    public Animator door;
    public PlayerStats2 player;
    public Hallicunation hall;
    bool started;

    void Update()
    {

    }

    void StartPuzzle()
    {
    	door.SetBool("OpenClose",false);
        door.SetTrigger("Door");
    }

    public void Bottle(int i)
    {
        if(i==1)
        {
            player.sanity=player.maxSanity;
        }
        if(i==2)
        {
            hall.StartHall();
        }
        if(i==3)
        {
        	door.SetBool("OpenClose",true);
            door.SetTrigger("Door");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="PuzzlePart" && started==false)
        {
            started=true;
            StartPuzzle();
        }
    }

}
