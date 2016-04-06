using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class MenuManager : MonoBehaviour {
	public GameObject player;
	public GameObject leftCanvas;
	public GameObject rightCanvas;
	public GameObject optionMenu;
	public GameObject[] allMenus;
	private bool showMenu = true;
	private bool showOptions = true;
	public bool canOpen = true;

	void Awake () {
		Cursor.visible = false;
		canOpen = true;
	}

	void GetInput () {
		if(Input.GetButtonDown("Cancel")) {
			if(canOpen == true) {
				EnableDisableMenu();
			}
		}
	}

	public void EnableDisableMenu () {
		Camera.main.GetComponent<DepthOfField>().enabled = showMenu;
		Cursor.visible = showMenu;
		leftCanvas.SetActive(showMenu);
		optionMenu.SetActive(false);
		showOptions = true;
		showMenu = !showMenu;
	}

	public void EnableDisableOptions () {
		rightCanvas.SetActive(showOptions);
		optionMenu.SetActive(showOptions);
		showOptions = !showOptions;
	}

	public void Resume () {
		DisableAll();
	}

	public void Restart () {
		DisableAll();
		SceneManager.LoadScene(0);
	}

	public void Exit () {
		Application.Quit();
	}

	void DisableAll () {
		for(int i = 0; i < allMenus.Length; i++){
			allMenus[i].SetActive(false);
			ResetBool();
		}
	}

	void ResetBool () {
		showMenu = true;
		showOptions = true;
	}

	void Update () {
		GetInput();
		print(canOpen);
	}
}