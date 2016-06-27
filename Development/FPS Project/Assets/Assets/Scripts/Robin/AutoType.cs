using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoType : MonoBehaviour {

	public float letterPause;
	public GameObject player;
	public AudioClip sound;

	public string message;

	void Start () {
		Cursor.visible = true;
		StartCoroutine(TypeText());
	}

	public IEnumerator TypeText () {
		player.GetComponent<QuickieController>().canMove = false;
		foreach (char letter in message.ToCharArray()) {
			GetComponent<Text>().text += letter;
			if (sound)
				GetComponent<AudioSource>().pitch = Random.Range(1f, 1.25f);
				GetComponent<AudioSource>().PlayOneShot (sound);
				yield return 0;
				yield return new WaitForSeconds (letterPause);
		}
	}
}
