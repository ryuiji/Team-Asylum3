using UnityEngine;
using System.Collections;

public class Shotgun : GunAbstract {

	public AudioClip pumpSound;
    public AudioClip addBullet;
    public bool cancelAfternext;

	public void OnEnable()
    {
        fireRate = 60 / roundsPerMinute;
        gunManager.pass = PassDelegates;
    }

    public override void Shoot()
    {
        GameObject muzzleSpawned = (GameObject) Instantiate(muzzle,firePoint.position,transform.rotation);
        muzzleSpawned.transform.SetParent(firePoint);
        StartCoroutine("RateOfFire");
        bulletsInClip--;
        print("firedAk");
        audioSource.PlayOneShot(fire);
        //bullet.GetComponent<Bullet>().damage=damage;
        IncreaseRecoil();
        Instantiate(bullet, firePoint.position + new Vector3(Random.Range(minRecoilX,maxRecoilX) * recoilAmount, Random.Range(minRecoilY, maxRecoilY) * recoilAmount, 0), firePoint.rotation);
        gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
    }

    public override IEnumerator Reload()
    {
        if(isReloading==false)
        {
            mayFire = false;
            isReloading = true;
            for (int i = 0; i < clipSize; i++)
            {
                if (bulletsInClip < clipSize && looseAmmo >=1)
                {
                    audioSource.PlayOneShot(addBullet);
                    bulletsInClip++;
                    looseAmmo--;
                    gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
                    yield return new WaitForSeconds(addBullet.length);
                    if (cancelAfternext == true)
                    {
                        cancelAfternext = false;
                        isReloading=false;
                        break;
                    }

                }
                if (bulletsInClip == clipSize)
                {
                    audioSource.PlayOneShot(pumpSound);
                    yield return new WaitForSeconds(pumpSound.length);
                    break;
                }

            }
            StartCoroutine("RateOfFire");
            isReloading = false;
        }


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
        audioSource=gunManager.gunAudio;
        gunManager.addAmmo = AddAmmo;
        gunManager.shoot = PullTrigger;
        gunManager.aim = Aim;
        gunManager.unAim = UnAim;
        gunManager.reload = Reload;
        gunManager.decrease = DecreaseRecoil;
        transform.position=normalSpot.position;
        transform.rotation=normalSpot.rotation;
        gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
    }

    public override void PullTrigger()
    {
        if (bulletsInClip >= 1)
        {
            if(isReloading==true)
            {
                cancelAfternext = true;
            }
            switch (fireMode)
            {
                case CurrentFireMode.SemiAutomatic:
                    if (Input.GetButtonDown("Fire1") && mayFire == true)
                    {
                        Shoot();
                    }
                    break;
                case CurrentFireMode.Automatic:
                    if (mayFire == true)
                    {
                        Shoot();
                    }
                    if (Input.GetButtonUp("Fire1"))
                    {
                        Shoot();
                    }
                    break;
                case CurrentFireMode.PumpAction:
                    if (mayFire == true)
                    {
                        Shoot();
                    }
                    break;
            }
        }
        else if(bulletsInClip==0)
        {
            if(Input.GetButton("Fire1") && mayFire==true)
            {
                audioSource.PlayOneShot(empty);
                StartCoroutine("RateOfFire");
            }
        }
    }

    public override void IncreaseRecoil()
    {
        if(recoilAmount<maxRecoilAmount)
        {
            recoilAmount+=0.1f;
        }
    }

    public override void DecreaseRecoil()
    {
        if (recoilAmount > 0 )
        {
            recoilAmount -= 1f * Time.deltaTime;
        }
    }

    public override IEnumerator RateOfFire()
    {
        mayFire = false;
       	audioSource.PlayOneShot(pumpSound);
        yield return new WaitForSeconds(pumpSound.length);
        mayFire = true;
    }

    public override void AddAmmo(int bullets)
    {
        looseAmmo+=bullets;
        gunManager.UpdateUI(bulletsInClip, looseAmmo, gunName);
    }
}
