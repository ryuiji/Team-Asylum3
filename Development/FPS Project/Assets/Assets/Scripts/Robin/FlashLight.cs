//Zet dit script op een lightsource. Een Spotlight werkt het beste.

using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {
	private bool canTurnOn;
	private bool hasStarted;
	public bool isOn;
	public float batteryEnergy;
	
	void Update () {
		GetInput();
		CheckFlashLight();
		DrainEnergy();
		CheckBattery();
	}

	void CheckFlashLight () {
		if(batteryEnergy > 0){
			canTurnOn = true;
		}else{
			GetComponent<Light>().enabled = false;
			isOn = false;
		}
	}

	void CheckBattery () {
		if(batteryEnergy < 30) {
			if(!hasStarted) {
				StartCoroutine(StartFlashing());
				hasStarted = true;
			}
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

	public IEnumerator StartFlashing () {
		float waitTime = Random.Range(0.0f,2.0f);
		while(true) {
			yield return new WaitForSeconds(waitTime);
			GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
			isOn = !isOn;
			yield return new WaitForSeconds(waitTime);
			isOn = !isOn;
			GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
		}
	}
}
