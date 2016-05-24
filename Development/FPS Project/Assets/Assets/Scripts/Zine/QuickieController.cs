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

    // Use this for initialization
    void Start()
    {
        canMove = true;
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
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
        CameraLook();
        if(canMove) {
            Animate();
        }
        //transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSpeedX * Time.deltaTime, 0);
        Debug.DrawRay(transform.position,Vector3.down);

    }



    public void Animate()
    {

        if(Input.GetAxis("Horizontal")>0)
        {
            anim.SetBool("Walk",false);
            anim.SetBool("strafe R",true);
            anim.SetBool("strafe L",false);
            if(Raycast(transform.right))
            {
                print("Hit something");
            }
            else
            {
                transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*moveSpeed,0,0);
            }
        }
        if (Input.GetAxis("Horizontal")<0)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("strafe L", true);
            anim.SetBool("strafe R", false);
            if (Raycast(-transform.right))
            {
                print("Hit something");
            }
            else
            {
                transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, 0);
            }
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            anim.SetBool("strafe R", false);
            anim.SetBool("strafe L", false);
            anim.SetBool("Walk", true);
            if (Raycast(transform.forward))
            {
                print("Hit something");
            }
            else
            {
                transform.Translate(0,0,Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
            }
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetBool("strafe R", false);
            anim.SetBool("strafe L", false);
            anim.SetBool("Walk", true);
            if (Raycast(-transform.forward))
            {
                print("Hit something");
            }
            else
            {
                transform.Translate(0, 0,Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
            }
        }
    }


    bool Raycast(Vector3 dir)
    {
        if(Physics.Raycast(rayCastObj.transform.position,dir,out hit, 0.5f) && hit.transform.tag!="PlayerPart")
        {
            print(hit.transform.name);
            return true;
        }
        else
        {
            return false;
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
