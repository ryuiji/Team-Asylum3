using UnityEngine;
using System.Collections;

public class GunDelegates : GunManager
{
    public Transform normalSpot, aimSpot;
    public float aimSpeed;

    delegate void FireGun();
    FireGun shoot;

    delegate void AddAmmunition(float ammo);
    AddAmmunition addAmmo;

    // Use this for initialization
    void Start()
    {
        UpdateUI();
        shoot = Shoot;
        addAmmo = AddAmmo;
        fireRate = 60 / roundsPerMinute;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void Aim()
    {
        print("aiming");
        transform.position = Vector3.MoveTowards(transform.position, aimSpot.position, aimSpeed * Time.deltaTime);
    }

    void GetInput()
    {
        if (Input.GetButton("Fire1"))
        {
            PullTrigger();
        }
        if (Input.GetButton("Fire2"))
        {
            Aim();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, normalSpot.position, aimSpeed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Reload"))
        {
            StartCoroutine("Reload");
        }
    }

    private void PullTrigger()
    {
        if (bulletsInClip >= 1)
        {
            switch (fireMode)
            {
                case GunFireMode.SemiAutomatic:
                    if (Input.GetButtonDown("Fire1") && mayFire == true)
                    {
                        shoot();
                        StartCoroutine("RateOfFire");
                    }
                    break;
                case GunFireMode.Automatic:
                    if (mayFire == true)
                    {
                        shoot();
                        StartCoroutine("RateOfFire");
                    }
                    if (Input.GetButtonUp("Fire1"))
                    {
                        shoot();
                        StartCoroutine("RateOfFire");
                    }
                    break;
                case GunFireMode.PumpAction:
                    if (mayFire == true)
                    {
                        shoot();
                        StartCoroutine("RateOfFire");
                    }
                    break;
                case GunFireMode.Melee:
                    if (Input.GetButtonDown("Fire1"))
                    {
                        //melee
                    }
                    break;
            }
        }
        else if (mayFire == true && bulletsInClip == 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(empty);
            }
        }
    }

}
