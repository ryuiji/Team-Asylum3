using UnityEngine;
using System.Collections;

public class ChangeWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ChangeWalls()
    {
        RaycastHit[] walls = Physics.SphereCastAll(transform.position,5f,transform.up);
        for(int i = 0; i<walls.Length; i++)
        {
            if(walls[i].transform.name == "Wall2")
            {

            }
        }
    }
}
