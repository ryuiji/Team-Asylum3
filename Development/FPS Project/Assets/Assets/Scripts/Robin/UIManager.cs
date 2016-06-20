using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public GameObject loadingScreen;

	public GameObject options;
	public GameObject credits;

	public GameObject graphics;
	public GameObject audio;
	public GameObject controls;

	public GameObject[] allOptions;

	private bool showMenu = true;
	private bool showCredits = true;


	void DisableAll () {
		for(int i = 0; i < allOptions.Length; i++) {
			allOptions[i].SetActive(false);
		}
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
