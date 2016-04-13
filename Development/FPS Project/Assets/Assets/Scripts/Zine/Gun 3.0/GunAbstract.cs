using UnityEngine;
using System.Collections;

public enum CurrentFireMode
{
    Melee,
    Automatic,
    PumpAction,
    SemiAutomatic,
}

public enum WeaponClass
{
    Primary,
    Secondary,
    Melee,
}

public abstract class GunAbstract : MonoBehaviour
{
    public string gunName;
    public float roundsPerMinute;
    public float reloadSpeed;
    public float clipSize;
    public float bulletsInClip;
    public float looseAmmo;
    public GameObject bullet;
    public Transform firePoint;
    public CurrentFireMode fireMode;
    public WeaponClass weaponClass;
    public bool mayFire = true;
    public float fireRate;
    public bool isReloading;
    public Gunmanage gunManager;
    public Transform aimSpot;
    public Transform normalSpot;
    public float aimSpeed;
    public int damage;
    public float minRecoilX;
    public float maxRecoilX;
    public float minRecoilY;
    public float maxRecoilY;
    public float recoilAmount;
    public float maxRecoilAmount;
    public GameObject muzzle;
    public Animator anim;

    [Header("Sound Files")]
    public AudioSource audioSource;
    public AudioClip fire;
    public AudioClip reload;
    public AudioClip empty;


    public abstract void Shoot();

    public abstract IEnumerator Reload();

    public abstract void Aim();

    public abstract void UnAim();

    public abstract void PassDelegates();

    public abstract IEnumerator RateOfFire();

    public abstract void PullTrigger();

    public abstract void IncreaseRecoil();

    public abstract void DecreaseRecoil();

    public abstract void AddAmmo(int bullets);
}
