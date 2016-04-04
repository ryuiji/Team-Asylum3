using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GunManager : GunBase
{
    [Header("UI Elements")]
    public Text currentAmmoText;
    public Text looseAmmoText;
    public Text gunNameText;

    public void Shoot()
    {
        if (mayFire == true)
        {
            print("Yarak");
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            bulletsInClip--;
            audioSource.PlayOneShot(fire);
            UpdateUI();
        }
    }

    public IEnumerator Reload()
    {
        UpdateUI();
        mayFire = false;
        if (looseAmmo == 0)
        {
            print("cant reload brah");
            mayFire = true;
            StopCoroutine("Reload");
        }
        audioSource.PlayOneShot(reload);
        yield return new WaitForSeconds(reloadSpeed);
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
        UpdateUI();
    }

    public void AddAmmo(float ammoAmount)
    {
        looseAmmo += ammoAmount;
        UpdateUI();
        //play sound
    }

    public IEnumerator RateOfFire()
    {
        mayFire = false;
        yield return new WaitForSeconds(fireRate);
        mayFire = true;
    }

    public void UpdateUI()
    {
        looseAmmoText.text = looseAmmo.ToString("F0");
        currentAmmoText.text = bulletsInClip.ToString("F0");
        gunNameText.text = gunName;
    }


}
