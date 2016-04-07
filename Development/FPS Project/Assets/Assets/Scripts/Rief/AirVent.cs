using UnityEngine;
using System.Collections;

public class AirVent : MonoBehaviour {

    public GameObject airVent;
    public Rigidbody rb;
    private float force = 500f;
    private float hitRadius = 10f;
    private float hitDis = 10f;
    public int roomID;
    public bool canGo;

    void Start() {
        rb = airVent.GetComponent<Rigidbody>();
    }


    void OnTriggerEnter(Collider airVentForce) {
        if (airVentForce.gameObject.tag == "Player" && canGo == true){
            AirVentAction(roomID);
        }
    }

    void AirVentAction(int RoomID) {
        rb.AddForce(Vector3.up * force);
        RaycastHit[] hit = Physics.SphereCastAll(airVent.transform.position, hitRadius, Vector3.forward, hitDis);
        for (int i = 0; i < hit.Length; i++) {
            if(hit[i].transform.tag == "Deur") {
                if (hit[i].transform.GetComponent<Door>().roomID == RoomID && hit[i].transform.GetComponent<Door>().isOpen == true) {
                    hit[i].transform.GetComponent<Door>().Open();
                }
            }
        }
        canGo = false;
    }
}
