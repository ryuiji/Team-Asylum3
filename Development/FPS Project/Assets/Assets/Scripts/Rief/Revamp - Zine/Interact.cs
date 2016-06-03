﻿using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour
{
    public RaycastHit hit;
    void Update()
    {
        if(Input.GetButtonDown("Use") && Physics.Raycast(transform.position,transform.forward,out hit, 5f))
        {
            if(hit.transform.GetComponent<Interactable2>()!=null)
            {
                InteractObj();
            }
        }
    }

    void InteractObj()
    {
        switch(hit.transform.GetComponent<Interactable2>().inter)
        {
            case InteractableEnum.Door:
                hit.transform.GetComponent<Door2>().UseDoor();
                break;
            case InteractableEnum.Battery:
                hit.transform.GetComponent<Battery2>().AddPower();
                break;
            case InteractableEnum.Key:
                GameObject.Find("FinalDoor").GetComponent<KeyManager>().AddOneKey();
                break;
        }
    }
}
