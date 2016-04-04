using UnityEngine;
using System.Collections;

public class RecoilScript : MonoBehaviour
{
    public GameObject mainCamera;
    public float recoilAmount;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            KickUp(recoilAmount);
        }
    }

    public void KickUp(float amount)
    {
        mainCamera.transform.Rotate(-5, 0, 0);
    }
}
