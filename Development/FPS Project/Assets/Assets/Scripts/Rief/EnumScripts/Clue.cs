using UnityEngine;
using System.Collections;

public class Clue : MonoBehaviour {
    public enum ClueManager {clueBed, clueBoard}
    public ClueManager clueManager;
    public GameObject clueCanvas;
	void Start () {
	
	}
	
	public void ClueFound () {
        clueCanvas.SetActive(true);
        switch (clueManager) {
            case ClueManager.clueBed:
            ClueBed();
            break;
            case ClueManager.clueBoard:
            ClueBoard();
            break;
            }
	}
    void ClueBed() {
        }
    void ClueBoard() {

        }
}
