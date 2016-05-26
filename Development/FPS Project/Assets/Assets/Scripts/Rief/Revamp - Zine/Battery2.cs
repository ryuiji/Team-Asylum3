using UnityEngine;
using System.Collections;

public class Battery2 : MonoBehaviour
{
    public FlashLight light;
    public float powerAdded;
    
    public void AddPower()
    {
        light.batteryEnergy+=powerAdded;
        Destroy(this.gameObject);
    }
}
