using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject bulletImpact;
    public float speed;
    public int damage;
    public RaycastHit hit;
    // Use this for initialization
    void Start()
    {
        transform.parent=null;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Collision();

    }

    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void Collision()
    {
        if (Physics.Raycast(transform.position, transform.forward,out hit, 3))
        {
            print("hit");
            //Instantiate(bulletImpact, transform.position, transform.rotation);
            if(hit.transform.tag=="EnemyBodyPart")
            {
                hit.transform.GetComponent<EnemyBodyParts>().DoDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }



}
