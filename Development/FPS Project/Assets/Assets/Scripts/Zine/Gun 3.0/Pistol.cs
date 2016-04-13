using UnityEngine;
using System.Collections;
using System;

public class Pistol : GunAbstract
{
    public void OnEnable()
    {
        fireRate = 60 / roundsPerMinute;
        gunManager.pass = PassDelegates;
    }

    public override void Shoot()
    {
        anim.SetTrigger("Attack Weapon");
        GameObject muzzleSpawned = (GameObject) Instantiate(muzzle,firePoint.position,transform.rotation);
        muzzleSpawned.transform.SetParent(firePoint);
        bulletsInClip--;
        print("firedPistol");
        audioSource.PlayOneShot(fire);
        bullet.GetComponent<Bullet>().damage = damage;
        IncreaseRecoil();
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
    }

    public override IEnumerator Reload()
    {
        if (isReloading == false)
        {
            anim.SetTrigger("Reload Weapon");
            gunManager.isReloading=true;
            StopCoroutine("RateOfFire");
            isReloading = true;
            mayFire = false;
            if (looseAmmo == 0)
            {
                print("cant reload brah");
                mayFire = true;
                StopCoroutine("Reload");
            }
            yield return new WaitForSeconds(0.8f);
            audioSource.PlayOneShot(reload);
            yield return new WaitForSeconds(reloadSpeed);
            isReloading = false;
            mayFire = true;
            if (looseAmmo >= clipSize)
            {
                print("1");
                looseAmmo -= clipSize - bulletsInClip;
                bulletsInClip = clipSize;
            }
            else if (looseAmmo < clipSize && looseAmmo > 0)
            {
                print("2");
                if (looseAmmo + bulletsInClip > clipSize)
                {
                    looseAmmo -= clipSize - bulletsInClip;
                    bulletsInClip = clipSize;
                }
                else
                {
                    bulletsInClip += looseAmmo;
                    looseAmmo -= looseAmmo;
                }

            }
            gunManager.isReloading = true;
        }
        gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
    }

    public override void Aim()
    {
        transform.position = Vector3.MoveTowards(transform.position, aimSpot.position, aimSpeed * Time.deltaTime);
    }

    public override void UnAim()
    {
        transform.position = Vector3.MoveTowards(transform.position, normalSpot.position, aimSpeed * Time.deltaTime);
    }

    public override void PassDelegates()
    {
        audioSource = gunManager.gunAudio;
        gunManager.shoot = PullTrigger;
        gunManager.aim = Aim;
        gunManager.unAim = UnAim;
        gunManager.reload = Reload;
        gunManager.decrease = DecreaseRecoil;
        gunManager.addAmmo = AddAmmo;
        transform.position=normalSpot.position;
        transform.rotation=normalSpot.rotation;
        gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
    }

    public override void PullTrigger()
    {
        if (bulletsInClip >= 1)
        {
            switch (fireMode)
            {
                case CurrentFireMode.SemiAutomatic:
                    if (Input.GetButtonDown("Fire1") && mayFire == true)
                    {
                        Shoot();
                        StartCoroutine("RateOfFire");
                    }
                    break;
                case CurrentFireMode.Automatic:
                    if (mayFire == true)
                    {
                        Shoot();
                        StartCoroutine("RateOfFire");
                    }
                    if (Input.GetButtonUp("Fire1"))
                    {
                        Shoot();
                        StartCoroutine("RateOfFire");
                    }
                    break;
                case CurrentFireMode.PumpAction:
                    if (mayFire == true)
                    {
                        Shoot();
                        StartCoroutine("RateOfFire");
                    }
                    break;
            }
        }
        else if (bulletsInClip == 0)
        {
            if (Input.GetButton("Fire1") && mayFire == true)
            {
                audioSource.PlayOneShot(empty);
                StartCoroutine("RateOfFire");
            }
        }
    }

    public override void IncreaseRecoil()
    {
        if (recoilAmount < maxRecoilAmount)
        {
            recoilAmount += 0.5f * Time.deltaTime;
        }
    }

    public override void DecreaseRecoil()
    {
        if (recoilAmount > 0)
        {
            recoilAmount -= 0.5f * Time.deltaTime;
        }
    }

    public override IEnumerator RateOfFire()
    {
        mayFire = false;
        yield return new WaitForSeconds(fireRate);
        mayFire = true;
    }

    public override void AddAmmo(int bullets)
    {
        looseAmmo += bullets;
        gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
    }
}
