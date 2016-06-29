//Zet dit script op een lightsource. Een Spotlight werkt het beste.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour {
	private bool canTurnOn;
	private bool hasStarted;
	public bool isOn;
	public float batteryEnergy;
	public GameObject batteryBar;
	
	void Update () {
		GetInput();
		CheckFlashLight();
		DrainEnergy();
		batteryBar.GetComponent<Slider>().value = batteryEnergy;
	}

	void CheckFlashLight () {
		if(batteryEnergy > 0){
			canTurnOn = true;
		}else{
			GetComponent<Light>().enabled = false;
			isOn = false;
		}
	}

	void DrainEnergy () {
		if(isOn == true){
			batteryEnergy -= Time.deltaTime;
		}
	}

	void GetInput () {
		if(Input.GetButtonDown("FlashLight")){
			if(canTurnOn == true){
				GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
				GetComponent<LightShafts>().enabled = !isOn;
				isOn = !isOn;
			}
		}
	}
}
