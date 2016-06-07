using UnityEngine;
using System.Collections;

public class QuickieController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject camera;
    [Range(100, 360)]
    public float mouseSpeedX;
    [Range(100, 360)]
    public float mouseSpeedY;
    private float x = 0;
    public float maxX;
    public float minX;
    public float jumpForce;
    public bool hasJumped;
    public bool canMove;
    public RaycastHit hit;
    public Rigidbody rigid;
    public Animator anim;
    public Transform rayCastObj;
    public Transform collisionObj;

    [Header("Camera Vars")]
    public float lookSensitivity = 5;
    public float yRotation;
    public float xRotation;
    public float curYrot;
    public float curXrot;
    public float yRotV;
    public float xRotV;
    public float lookSmoothDamp = 0.1f;
    public Transform body;

    void Start()
    {
        canMove = true;
        //Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void CameraLook()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;

        xRotation = Mathf.Clamp(xRotation, -90, 50);

        curXrot = Mathf.SmoothDamp(curXrot, xRotation, ref xRotV, lookSmoothDamp);
        curYrot = Mathf.SmoothDamp(curYrot, yRotation, ref yRotV, lookSmoothDamp);


        camera.transform.rotation = Quaternion.Euler(curXrot, transform.eulerAngles.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            CameraLook();
            transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSpeedX * Time.deltaTime, 0);
            transform.Translate(Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime,0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
            if(Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal")==0)
            {
                rigid.velocity=Vector3.zero;
            }
        }

    }


    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
