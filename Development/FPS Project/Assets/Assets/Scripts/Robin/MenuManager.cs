using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class MenuManager : MonoBehaviour {
	public GameObject background;
	private bool canFade;
	public GameObject player;
	public GameObject leftCanvas;
	public GameObject rightCanvas;
	public GameObject optionMenu;
	public GameObject[] allMenus;
	private bool showMenu = true;
	private bool showOptions = true;
	public bool canOpen;

	void Awake () {
		background.SetActive(true);
		canFade = true;
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
		player.GetComponent<QuickieController>().canMove = showMenu;
		
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
		if(canFade) {
			background.GetComponent<CanvasGroup>().alpha -= Time.deltaTime / 5;
		}
	}
}