using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class NoteBook : MonoBehaviour {

	public GameObject notebook;
	public GameObject player;

	public void DisableNoteBook () {
		notebook.SetActive(false);
		Cursor.visible = false;
		player.GetComponent<QuickieController>().canMove = true;
		Camera.main.GetComponent<DepthOfField>().enabled = false;
	}
}
