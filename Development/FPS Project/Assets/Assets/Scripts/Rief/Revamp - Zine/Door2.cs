using UnityEngine;
using System.Collections;

public class Door2 : MonoBehaviour
{
    public bool open;
    public Animator door;

    void Start()
    {
        if(open)
        {
            UseDoor();
        }
    }

    public void UseDoor()
    {
        door.SetTrigger("Door");
        /*

			UI UPDATE
        */
    }
}
