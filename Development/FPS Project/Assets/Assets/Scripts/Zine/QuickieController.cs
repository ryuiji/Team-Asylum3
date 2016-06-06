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

    void Start()
    {
        canMove = true;
        //Cursor.lockState=CursorLockMode.Locked;
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
        if(canMove) {
            Animate();
            CameraLook();
            GetRot();
            transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSpeedX * Time.deltaTime, 0);
        }
        if (!Raycast())
        {
            transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        }
        //Debug.DrawRay(transform.position,Vector3.down);

    }


    Vector3 GetRot()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(hor,0,vert);
        Debug.DrawRay(transform.position,new Vector3(hor,0,vert), Color.red);
        return dir;
        //Vector3 direc = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        ////direc+=transform.position;
        //Quaternion lookRot = Quaternion.LookRotation(direc);
        //print(direc*10);
        //Debug.DrawRay(transform.position,-direc*10,Color.red);      
    }



    public void Animate()
    {

        //if(Input.GetAxis("Horizontal")>0)
        //{
        //    anim.SetBool("Walk",false);
        //    anim.SetBool("strafe R",true);
        //    anim.SetBool("strafe L",false);
        //    if(Raycast())
        //    {
        //        print("Hit something");
        //    }
        //    else
        //    {
        //        transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*moveSpeed,0,0);
        //    }
        //}
        //if (Input.GetAxis("Horizontal")<0)
        //{
        //    anim.SetBool("Walk", false);
        //    anim.SetBool("strafe L", true);
        //    anim.SetBool("strafe R", false);
        //    if (Raycast())
        //    {
        //        print("Hit something");
        //    }
        //    else
        //    {
        //        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, 0);
        //    }
        //}
        //if (Input.GetAxis("Vertical") > 0)
        //{
        //    anim.SetBool("strafe R", false);
        //    anim.SetBool("strafe L", false);
        //    anim.SetBool("Walk", true);
        //    if (Raycast())
        //    {
        //        print("Hit something");
        //    }
        //    else
        //    {
        //        transform.Translate(0,0,Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
        //    }
        //}
        //if (Input.GetAxis("Vertical") < 0)
        //{
        //    anim.SetBool("strafe R", false);
        //    anim.SetBool("strafe L", false);
        //    anim.SetBool("Walk", true);
        //    if (Raycast())
        //    {
        //        print("Hit something");
        //    }
        //    else
        //    {
        //        transform.Translate(0, 0,Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
        //    }
        //}
    }


    bool Raycast()
    {
        if(Physics.Raycast(rayCastObj.transform.position,GetRot(),out hit, 1f) && hit.transform.tag!="PlayerPart")
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
