using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour
{
    public Animator door;
    public PlayerStats2 player;
    public Hallicunation hall;

    void StartPuzzle()
    {
        door.SetTrigger("Door");
    }

    public void Bottle(int i)
    {
        if(i==0)
        {
            player.sanity=player.maxSanity;
        }
        if(i==1)
        {
            hall.StartHall();
        }
        if(i==2)
        {
            door.SetTrigger("Door");
        }
    }
}
