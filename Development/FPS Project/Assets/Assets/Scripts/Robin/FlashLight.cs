//Zet dit script op een lightsource. Een Spotlight werkt het beste.

using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {
	private bool canTurnOn;
	public bool isOn;
	public float batteryEnergy;
	
	void Update () {
		GetInput();
		CheckFlashLight();
		DrainEnergy();
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
				isOn = !isOn;
			}
		}
	}
}
