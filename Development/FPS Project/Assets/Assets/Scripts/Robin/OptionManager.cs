using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class OptionManager : MonoBehaviour {

	public GameObject graphics;
	public GameObject audio;
	public GameObject controls;
	public GameObject[] allOptions;

	public GameObject graphicDropdown; // De toggle
	public GameObject antiAliasing; // Toggle
	public GameObject bloom; // Toggle

	public void ChangeQuality () {
		QualitySettings.SetQualityLevel(graphicDropdown.GetComponent<Dropdown>().value);
		Camera.main.GetComponent<Antialiasing>().enabled = antiAliasing.GetComponent<Toggle>().isOn;
		Camera.main.GetComponent<Bloom>().enabled = bloom.GetComponent<Toggle>().isOn;
	}

	public void EnableDisableGraphics () {
		DisableAll();
		graphics.SetActive(true);
	}

	public void EnableDisableAudio () {
		DisableAll();
		audio.SetActive(true);
	}

	public void EnableDisableControls () {
		DisableAll();
		controls.SetActive(true);
	}

	void DisableAll () {
		for(int i = 0; i < allOptions.Length; i++){
			allOptions[i].SetActive(false);
		}
	}
}
