using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public enum Type { Enemy, Furniture };
public class Gizmo : MonoBehaviour {
    public Type type;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        switch(type)
        {
            case Type.Enemy:
                Gizmos.DrawIcon(transform.position,"EnemyIcon");
                break;
            case Type.Furniture:
                Gizmos.DrawIcon(transform.position,"Furniture");
                break;
        }
    }
}
