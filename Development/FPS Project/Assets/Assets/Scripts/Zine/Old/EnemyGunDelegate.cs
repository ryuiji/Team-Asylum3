using UnityEngine;
using System.Collections;

public class EnemyGunDelegate : GunManager
{
    delegate void FireGun();
    FireGun shoot;
    public float accuracy;
    public bool mayReload = true;
    public Transform player;

    void Start()
    {
        shoot = Shoot;
        fireRate=60/roundsPerMinute;
    }

    // Update is called once per frame
    void Update()
    {
        AI();
    }

    void AI()
    {
        transform.LookAt(player);
        if(bulletsInClip==0 && mayReload==true)
        {
            print("doingthisReload");
            StartCoroutine("Reload");
            mayReload=false;
        }
        if (bulletsInClip > 0)
        {
            mayReload=true;
            if(mayFire==true)
            {
                StartCoroutine("EnemyShoot");
            }
        }

    }

    IEnumerator EnemyShoot()
    {
        shoot();
        mayFire = false;
        yield return new WaitForSeconds(fireRate);
        mayFire=true;
    }


}
