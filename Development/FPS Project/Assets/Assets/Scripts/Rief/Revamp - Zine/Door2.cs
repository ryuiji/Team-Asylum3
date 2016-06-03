using UnityEngine;
using System.Collections;

public class Door2 : MonoBehaviour
{
    public bool open;
    public Animator door;

    void Start()
    {
        door=GetComponent<Animator>();
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
