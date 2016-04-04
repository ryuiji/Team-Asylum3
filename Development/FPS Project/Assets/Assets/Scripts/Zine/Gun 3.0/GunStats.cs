using UnityEngine;
using System.Collections;

public class GunStats : MonoBehaviour
{
    public string gunName;
    public float roundsPerMinute;
    public float reloadSpeed;
    public float clipSize;
    public float bulletsInClip;
    public float looseAmmo;
    public GameObject bullet;
    public Transform firePoint;
    public GunFireMode fireMode;
    public bool mayFire = true;
    public float fireRate;

    [Header("Sound Files")]
    public AudioSource audioSource;
    public AudioClip fire;
    public AudioClip reload;
    public AudioClip empty;
}
