using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clue : MonoBehaviour {
    public GameObject clueCanvas;
    public int clueNumber;
    public string[] clues;
    private int clueMinus = 1;
    void Start () {
        clueCanvas.SetActive(false);
    }
	
	public void ClueFound () {
        clueCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        clueCanvas.GetComponentInChildren<Text>().text = clues[clueNumber-clueMinus];
    }
    public void ExitClues() {
        clueCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}