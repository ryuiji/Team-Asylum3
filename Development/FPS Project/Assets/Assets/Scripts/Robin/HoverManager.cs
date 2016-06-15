using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverManager : MonoBehaviour {

	public Color highlightColor;
	private Color curColor;

	public void Hover (GameObject obj) {
		curColor = obj.GetComponent<Text>().color;
		obj.GetComponent<Text>().color = highlightColor;
	}

	public void ExitHover (GameObject obj) {
		obj.GetComponent<Text>().color = curColor;
	}
}
