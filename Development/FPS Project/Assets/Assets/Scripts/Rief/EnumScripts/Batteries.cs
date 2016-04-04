using UnityEngine;
using System.Collections;

public class Batteries : MonoBehaviour {

    public GameObject flashLight; //zet flashlight erin.
    FlashLight flashlight;
    private float batteryValue = 60f;

    public void Start() {
        flashlight = flashLight.GetComponent<FlashLight>();
    }
    public void BatteriesAmmo() {
        flashlight.batteryEnergy += batteryValue;
    }
}
