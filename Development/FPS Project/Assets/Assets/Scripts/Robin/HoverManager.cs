using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverManager : MonoBehaviour {

	public Color highlightColor;
	private Color curColor;
	private AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
	}

	public void Hover (GameObject obj) {
		curColor = obj.GetComponent<Text>().color;
		obj.GetComponent<Text>().color = highlightColor;
		HoverSound();
	}

	void HoverSound () {
		audio.Play();
		audio.pitch = Random.Range(1f, 1.2f);
	}

	public void ExitHover (GameObject obj) {
		obj.GetComponent<Text>().color = curColor;
	}
}
