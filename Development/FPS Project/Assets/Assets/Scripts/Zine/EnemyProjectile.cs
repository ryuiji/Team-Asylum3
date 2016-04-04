using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        transform.position+=transform.forward*projectileSpeed*Time.deltaTime;
        if(Vector3.Distance(player.transform.position,transform.position)<2f)
        {
            Hit();
        }
    }

    void Hit()
    {
        player.GetComponent<MakeShiftHp>().TakeDamage(10);
        Destroy(this.gameObject);
    }
}
