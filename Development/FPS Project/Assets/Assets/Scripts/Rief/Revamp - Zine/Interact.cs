using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour
{
    public RaycastHit hit;
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.green);
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
                Destroy(hit.transform.gameObject);
                break;
            case InteractableEnum.Bottle:
                hit.transform.GetComponent<Bottle2>().UseBottle();
                break;
            case InteractableEnum.ElectricSwitch:
                hit.transform.GetComponent<ElectricSwitch>().StartCoroutine("Activate");
                break;
            case InteractableEnum.DoorSwitch:
                hit.transform.GetComponent<DoorSwitch>().Use();
                break;
        }
    }
}
