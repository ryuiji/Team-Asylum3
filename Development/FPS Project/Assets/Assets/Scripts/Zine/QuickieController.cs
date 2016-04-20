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
    public RaycastHit hit;
    public Rigidbody rigid;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSpeedX * Time.deltaTime, 0);
        camera.transform.Rotate(-Input.GetAxis("Mouse Y") * mouseSpeedX * Time.deltaTime, 0, 0);
        Debug.DrawRay(transform.position,Vector3.down);
        if(Physics.Raycast(transform.position,Vector3.down,out hit, 0.5f))
        {
            print(hit.transform.name);
            if(hit.transform.tag!="PlayerPart")
            {
                hasJumped=false;
                rigid.useGravity = false;
                rigid.velocity = new Vector3(0, 0, 0);
            }

        }
        else
        {
            rigid.useGravity=true;
        }
        if(Input.GetButtonDown("Jump") && hasJumped==false)
        {
            hasJumped=true;
            rigid.velocity = new Vector3(0,jumpForce,0);
        }
    }


    public void Animate()
    {

        if(Input.GetAxis("Horizontal")>0)
        {
            anim.SetBool("Walk",false);
            anim.SetBool("strafe R",true);
            anim.SetBool("strafe L",false);
        }
        if (Input.GetAxis("Horizontal")<0)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("strafe L", true);
            anim.SetBool("strafe R", false);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            anim.SetBool("strafe R", false);
            anim.SetBool("strafe L", false);
            anim.SetBool("Walk", true);
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
