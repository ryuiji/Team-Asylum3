using UnityEngine;
using System.Collections;

public class AirVent : MonoBehaviour {

    public GameObject airVent;
    public Rigidbody rb;
    private float force = 500f;

    void Start() {
        rb = airVent.GetComponent<Rigidbody>();
    }
	

	void OnTriggerEnter(Collider airVentForce) {
        if(airVentForce.gameObject.tag == "Player") {
            rb.AddForce(Vector3.up * force);
        }
	}
}
