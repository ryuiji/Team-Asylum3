using UnityEngine;
using System.Collections;

public class UseScript : MonoBehaviour {

    public RaycastHit hit;
    private float rayDis = 10f;


	void Start () {
        
    }
    void Update() {
        ButtonInput();
    }
    void CanInteract(RaycastHit hit) {
        Bottle bottleP = hit.transform.GetComponent<Bottle>();
        Ammo ammoP = hit.transform.GetComponent<Ammo>();
            
        switch (hit.transform.GetComponent<Interactable>().interact) {
            case Interactable.Interact.Door:
                hit.transform.GetComponent<Door>().Open();
                break;
            case Interactable.Interact.FalseBottle:
                bottleP.FalseBottle();
                break;
            case Interactable.Interact.TrueBottle:
                bottleP.TrueBottle();
                break;
            case Interactable.Interact.DeskConversation:
                hit.transform.GetComponent<DeskConversation>().Desk();
                break;
            case Interactable.Interact.PistolAmmo:
                ammoP.PistolAmmo();
                break;
            case Interactable.Interact.AKAmmo:
                ammoP.AKAmmo();
                break;
            case Interactable.Interact.ShotgunAmmo:
                ammoP.ShotgunAmmo();
                break;
            case Interactable.Interact.Batteries:
                hit.transform.GetComponent<Batteries>().BatteriesAmmo();
                break;
        }
    }
    void ButtonInput() {
        if (Input.GetButtonDown("Use")) {
            if(Physics.Raycast(transform.position,transform.forward,out hit, rayDis)) {
                CanInteract(hit);
            }
        }
    }
	


}
