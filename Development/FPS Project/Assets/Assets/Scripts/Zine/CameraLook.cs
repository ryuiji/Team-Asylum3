using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour
{
    public float lookSensitivity = 5;
    public float yRotation;
    public float xRotation;
    public float curYrot;
    public float curXrot;
    public float yRotV;
    public float xRotV;
    public float lookSmoothDamp = 0.1f;
    public Transform body;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
