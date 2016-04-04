using UnityEngine;
using System.Collections;

public class AmmoPackage : MonoBehaviour
{
	public enum AmmoType
	{
		Rifle,
		Pistol,
		Shotgun,
	}
	public AmmoType ammoType;
    public int ammoToAdd;

    public void AddAmmo(GameObject other)
    {
    	print("Collision");
        other.transform.GetComponent<Gunmanage>().addAmmo(ammoToAdd);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag=="Player")
        {
            AddAmmo(other.gameObject);
        }
    }

}
