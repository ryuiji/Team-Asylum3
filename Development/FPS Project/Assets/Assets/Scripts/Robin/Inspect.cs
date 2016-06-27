using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inspect : MonoBehaviour {
	public GameObject player;
	public float rayDistance;
	public GameObject inspectText;
	public GameObject inspectCanvas;
	public Transform tempPosition;
	public GameObject name;
	public GameObject weight;
	public GameObject tip;
	public GameObject description;

	private GameObject inspectObject;
	private bool inspecting;
	private RaycastHit hit;
	private Vector3 oldPosition;
	private Quaternion oldRotation;
	private float rotateSpeed = 750;

	void Update () {
		CheckBool();
		GetInput();
	}

	void CheckBool () {
		if(inspecting == false){
			ShootRay();
		}else{
			InspectObject(hit);
		}
	}

	void GetInput () {
		if(inspecting == true) {
			if(Input.GetButtonDown("Cancel")) {
				DisableInspecting();
			}
		}
	}

	void ShootRay () {
		Debug.DrawRay(transform.position, transform.forward * 5, Color.red);
		if(Physics.Raycast(transform.position, transform.forward, out hit, rayDistance)) {
			CheckTag(hit);
		}else{
			inspectText.SetActive(false);
		}
	}

	void CheckTag (RaycastHit hit) {
		Debug.Log("1");
		if(hit.transform.tag == "Inspect") {
			inspectText.SetActive(true);
			if(Input.GetButtonDown("Use")) {
				SavePosition(hit);
				inspecting = true;
				InspectObject(hit);
				inspectText.SetActive(false);
			}
		}
	}

	void SavePosition (RaycastHit hit) {
		oldPosition = hit.transform.position;
		oldRotation = hit.transform.rotation;

	}

	void InspectObject (RaycastHit hit) {
		Cursor.visible = true;
		DisableMovement();
		GetInfo();
		inspectCanvas.SetActive(true);
		SetObjectToTempLocation();
		if(Input.GetButton("Fire1")) {
			hit.transform.Rotate(Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime, -Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime,0, Space.World);
		}
	}

	void DisableInspecting () {
		inspecting = false;
		Cursor.visible = false;
		EnableMovement();
		SetObjectToOldLocation();		
		inspectCanvas.SetActive(false);
	}

	void SetObjectToTempLocation () {
		hit.transform.gameObject.layer = 8;
		hit.transform.position = tempPosition.position;
	}

	void SetObjectToOldLocation () {
		Transform transform = hit.transform;
		transform.gameObject.layer = 0;
		transform.position = oldPosition;
		transform.rotation = oldRotation;
	}

	void GetInfo () {
		ItemStats itemStats = hit.transform.gameObject.GetComponent<ItemStats>();
		name.GetComponent<Text>().text = itemStats.name;
		weight.GetComponent<Text>().text = itemStats.weight.ToString();
		tip.GetComponent<Text>().text = itemStats.tip;
		description.GetComponent<Text>().text = itemStats.description;
	}

	void DisableMovement () {
		player.GetComponent<QuickieController>().canMove = false;
	}

	void EnableMovement () {
		player.GetComponent<QuickieController>().canMove = true;
	}
}
