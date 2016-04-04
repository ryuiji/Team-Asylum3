using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int hp;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetHit(int damage)
    {
        hp-=damage;
        print(damage.ToString("F0"));
        if(hp<0)
        {
            Destroy(this.gameObject);
        }
    }
}
