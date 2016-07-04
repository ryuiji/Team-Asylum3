using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interact : MonoBehaviour
{
    public RaycastHit hit;
    public Text useText;
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
        if(Physics.Raycast(transform.position,transform.forward,out hit, 5f) && hit.transform.GetComponent<Interactable2>()!=null)
        {
            ShowToolTip();
        }
        else
        {
            useText.enabled=false;
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


    void ShowToolTip()
    {
        useText.enabled=true;
        switch(hit.transform.GetComponent<Interactable2>().inter)
        {
            case InteractableEnum.Door:
                if(hit.transform.GetComponent<Door2>().open==true)
                {
                    useText.text=("(E) Open Door");
                }
                else
                {
                    useText.text=("(E) Close Door");
                }
                break;
            case InteractableEnum.Battery:
                useText.text=("(E) Pick Up");
                break;
            case InteractableEnum.Key:
                useText.text=("(E) Pick Up");
                break;
            case InteractableEnum.Bottle:
                useText.text=("(E) Drink Bottle");
                break;
            case InteractableEnum.ElectricSwitch:
                if(hit.transform.GetComponent<ElectricSwitch>().active)
                {
                    useText.text=("(E) Turn Off");
                }
                else
                {
                    useText.text=("(E) Turn On");
                }
                break;
            case InteractableEnum.DoorSwitch:
                if(hit.transform.GetComponent<DoorSwitch>().on)
                {
                    useText.text=("(E) Close Door");
                }
                else
                {
                    useText.text=("(E) Open Door");
                }
                break;
        }
    }
}
