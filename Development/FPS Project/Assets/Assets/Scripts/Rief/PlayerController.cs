using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    public CharacterController cc;
    private Vector3 movement;
    private float walking;
    public float moveSpeed = 4f;
    public float runSpeed = 8f;
    public float rotateSpeed = 4f;
    private float jumpForce = 7f;
    private float gravity = 10f;
    public Vector3 tempRotation;
    public float curRot;
    public bool mayWalk;

    void Start() {
        mayWalk = true;
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        if (mayWalk == true) {
            MouseMoveClamp();
            Jump();
            Sprint();
        }
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement *= walking * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        cc.Move(movement);
    }

    void MouseMoveClamp() {
        float vertical = rotateSpeed * -Input.GetAxis("Mouse Y");
        float horizontal = rotateSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontal, 0);
        curRot += vertical;
        curRot = Mathf.Clamp(curRot, -70, 30);
        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(curRot, Camera.main.transform.localEulerAngles.y, Camera.main.transform.localEulerAngles.z);
        Camera.main.transform.localRotation = rot;
    }

    void Jump() {
        if (Input.GetButtonDown ("Jump") && cc.isGrounded) {
            movement.y = jumpForce;
        }
        movement.y -= gravity * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
    }
    void Sprint() {
        if (Input.GetButton("Sprint")){
            if (cc.isGrounded) {
                walking = runSpeed;
            }
        } else {
            walking = moveSpeed;
        }
    }
}
