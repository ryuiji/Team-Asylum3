using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public GameObject loadingScreen;
	public GameObject menu;
	public GameObject player;

	public GameObject options;
	public GameObject credits;

	public GameObject graphics;
	public GameObject audio;
	public GameObject controls;

	public GameObject[] allOptions;

	private bool showMenu = true;
	private bool showCredits = true;
	private bool canOpen = true;

	void DisableAll () {
		for(int i = 0; i < allOptions.Length; i++) {
			allOptions[i].SetActive(false);
		}
	}

	public void Resume () {
		DisableAll();
		menu.SetActive(false);
		Time.timeScale = 1;
		canOpen = true;
		Cursor.visible = false;
		EnableMovement();
	}

	void Update () {
		if(Input.GetButtonDown("Cancel")) {
			if(canOpen == true) {
				EnableMenu();
			} else if(Input.GetButtonDown("Cancel")) {
				Resume();
				EnableMovement();
			}
		}
	}

	void EnableMenu () {
		Cursor.visible = true;
		DisableMovement();
		Time.timeScale = 0;
		DisableAll();
		menu.SetActive(true);
		canOpen = false;
	}

	void EnableMovement () {
		player.GetComponent<QuickieController>().canMove = true;
	}

	void DisableMovement () {
		player.GetComponent<QuickieController>().canMove = false;
	}

	public void Back () {
		options.SetActive(false);
		ResetBool();
	}

	public void StartGame () {
		StartCoroutine(StartLevel());
	}

	public void ExitGame () {
		Application.Quit();
	}

	public void Options () {
		options.SetActive(showMenu);
		credits.SetActive(false);
		showCredits = true;
		showMenu = !showMenu;
	}

	public void Credits () {
		options.SetActive(false);
		credits.SetActive(showCredits);
		showMenu = true;
		showCredits = !showCredits;
	}

	public void Graphics () {
		DisableAll();
		graphics.SetActive(true);
	}

	public void Audio () {
		DisableAll();
		audio.SetActive(true);
	}

	public void Controls () {
		DisableAll();
		controls.SetActive(true);
	}

	public void IncreaseGraphics () {
		QualitySettings.IncreaseLevel(false);
	}

	public void DecreaseGraphics () {
		QualitySettings.DecreaseLevel(false);
	}

	private void ResetBool () {
		showMenu = true;
		showCredits = true;
	}

	public IEnumerator StartLevel() {
        AsyncOperation async = Application.LoadLevelAsync("MainBuild");
        loadingScreen.SetActive(true);
        yield return async;
        loadingScreen.SetActive(false);
        SceneManager.LoadScene("MainBuild");
    }
}
