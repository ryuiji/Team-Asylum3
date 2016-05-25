using UnityEngine;
using System.Collections;

public class Door2 : MonoBehaviour
{
    public Animator door;

    public void UseDoor()
    {
        door.SetTrigger("Door");
    }
}
