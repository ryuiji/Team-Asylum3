using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QualityManager : MonoBehaviour {

	private int qualityLevel;

	void Update () {
		qualityLevel = QualitySettings.GetQualityLevel();
		GetComponent<Text>().text = qualityLevel.ToString();
	}
}
