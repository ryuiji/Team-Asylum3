using UnityEngine;
using System.Collections;

public class ragdollController : MonoBehaviour {

	public Component[] bones;
	public Animator anim;
	public bool isDead;



	void Start () {
		bones = gameObject.GetComponentsInChildren<Rigidbody> (); 
		anim = GetComponent<Animator> ();
        StartGame();
        GetComponent<Rigidbody>().isKinematic=false;
        GetComponent<Collider>().enabled = true;
    }
    void Update ()

	{
		if (isDead)
			killRagdoll ();

	}

    void StartGame()
    {
        foreach(Rigidbody ragdoll in bones)
        {
            ragdoll.gameObject.GetComponent<Collider>().enabled=false;
            print("DidOne");
            ragdoll.isKinematic=true;
        }
    }


	void killRagdoll () 
	{
		foreach (Rigidbody ragdoll in bones)
		{
			ragdoll.isKinematic = false;
		}

		anim.enabled = false;
	}
}