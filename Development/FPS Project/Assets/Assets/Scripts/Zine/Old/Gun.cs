using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum FireType
{
    Automatic,
    SemiAutomatic,
    BoltOrPumpAction,
    BurstFire,
}



public class Gun : MonoBehaviour
{
    public FireType fireType;
    public float roundsPerMinute;
    public float timeBetweenShots;
    public int burstAmount;
    public float timeBetweenBurst;
    public float burstSpeed;
    public AudioClip pumpSound;
    public float fireRate;
    public float semiFireRate;
    public float pumpTime;
    public int ammoInClip;
    public int fullAmmoInClip;
    public int looseAmmo;
    public float reloadSpeed;
    private bool mayFire = true;
    public AudioClip emptySound;
    public AudioClip shot;
    public AudioSource audioSource;
    public AudioClip reloadSound;
    public Text clip, loose;
    public Transform firePoint;
    public GameObject clipObj;
    public GameObject bullet;
    public Transform aimSpot;
    public Transform normalSpot;
    public float recoilAmount;
    public float recoilLength;
    public Recoil recoil;
    // Use this for initialization
    void Start()
    {
        UpdateUI();
        audioSource = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        GetInPut();
    }



    void GetInPut()
    {
        if (Input.GetMouseButton(1))
        {
            transform.position = aimSpot.position;
        }
        else
        {
            transform.position = normalSpot.position;
        }

        if (Input.GetButton("Fire1"))
        {
            fireRate = 60 / roundsPerMinute;
            print(fireRate);
            Fire();
        }
        if (Input.GetButtonDown("Reload") && ammoInClip != fullAmmoInClip)
        {
            StopAllCoroutines();
            StartCoroutine("Reload");
        }
    }

    void Fire()
    {
        if (ammoInClip >= 1)
        {
            switch (fireType)
            {
                case FireType.SemiAutomatic:
                    if (Input.GetButtonDown("Fire1") && mayFire == true)
                    {
                        StartCoroutine("CooldownSemiAuto");
                        FireBullet();
                    }
                    break;
                case FireType.Automatic:
                    if (mayFire == true)
                    {
                        FireBullet();
                        StartCoroutine("Cooldown");
                    }
                    if (Input.GetButtonUp("Fire1"))
                    {
                        StopCoroutine("Cooldown");
                        mayFire = true;
                    }
                    break;
                case FireType.BoltOrPumpAction:
                    if (mayFire == true)
                    {
                        FireBullet();
                        StartCoroutine("Pump");
                    }
                    break;
                case FireType.BurstFire:
                    if (Input.GetButtonDown("Fire1") && ammoInClip >= burstAmount && mayFire == true)
                    {
                        StartCoroutine("BurstFire");
                    }
                    break;
            }
        }
        else if (mayFire == true && ammoInClip == 0)
        {
            switch (fireType)
            {
                case FireType.Automatic:
                    audioSource.PlayOneShot(emptySound);
                    StartCoroutine("Empty");
                    break;
                case FireType.SemiAutomatic:
                    if (Input.GetButtonDown("Fire1"))
                    {
                        StartCoroutine("Empty");
                        audioSource.PlayOneShot(emptySound);
                    }
                    break;
                case FireType.BoltOrPumpAction:
                    if (Input.GetButtonDown("Fire1"))
                    {
                        StartCoroutine("Empty");
                        audioSource.PlayOneShot(emptySound);
                    }
                    break;
            }
        }

    }

    void UpdateUI()
    {
        clip.text = ammoInClip.ToString();
        loose.text = looseAmmo.ToString();
    }

    void FireBullet()
    {
        recoil.StartShake(recoilAmount,fireRate);
        audioSource.PlayOneShot(shot);
        Instantiate(bullet, firePoint.transform.position, firePoint.rotation);
        ammoInClip--;
        print("boom headshot");
        UpdateUI();
    }

    IEnumerator BurstFire()
    {
        mayFire = false;
        for (int i = 0; i < burstAmount; i++)
        {
            FireBullet();
            yield return new WaitForSeconds(burstSpeed);
        }
        yield return new WaitForSeconds(timeBetweenBurst);
        mayFire = true;
    }

    IEnumerator Cooldown()
    {
        mayFire = false;
        yield return new WaitForSeconds(fireRate);
        mayFire = true;
    }

    IEnumerator CooldownSemiAuto()
    {
        mayFire = false;
        yield return new WaitForSeconds(semiFireRate);
        mayFire = true;
    }

    IEnumerator Empty()
    {
        print("StartCooldown");
        mayFire = false;
        yield return new WaitForSeconds(emptySound.length);
        mayFire = true;
        print(mayFire);
    }


    IEnumerator Pump()
    {
        mayFire = false;
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(pumpSound);
        yield return new WaitForSeconds(pumpSound.length);
        mayFire = true;
    }

    IEnumerator Reload()
    {
        mayFire = false;
        audioSource.PlayOneShot(reloadSound);
        if (looseAmmo == 0)
        {
            print("cant reload brah");
            UpdateUI();
            audioSource.Stop();
            mayFire = true;
            StopCoroutine("Reload");
        }
        clipObj.SetActive(false);
        yield return new WaitForSeconds(reloadSound.length);
        mayFire = true;
        if (looseAmmo >= fullAmmoInClip)
        {
            print("1");
            looseAmmo -= fullAmmoInClip - ammoInClip;
            ammoInClip = fullAmmoInClip;
        }
        else if (looseAmmo < fullAmmoInClip && looseAmmo > 0)
        {
            print("2");
            if (looseAmmo + ammoInClip > fullAmmoInClip)
            {
                looseAmmo -= fullAmmoInClip - ammoInClip;
                ammoInClip = fullAmmoInClip;
            }
            else
            {
                ammoInClip += looseAmmo;
                looseAmmo -= looseAmmo;
            }

        }
        clipObj.SetActive(true);
        UpdateUI();
    }


    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

}
