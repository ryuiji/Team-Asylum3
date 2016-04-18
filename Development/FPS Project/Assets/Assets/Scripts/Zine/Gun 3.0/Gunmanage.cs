using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Gunmanage : MonoBehaviour
{
    public delegate void ShootGun();
    public ShootGun shoot;
    public delegate IEnumerator ReloadGun();
    public ReloadGun reload;
    public delegate void Aim();
    public Aim aim;
    public delegate void UnAim();
    public UnAim unAim;
    public delegate void PassDelegates();
    public PassDelegates pass;
    public delegate void DecreaseRecoil();
    public DecreaseRecoil decrease;
    public delegate void AddAmmo(int bullets);
    public AddAmmo addAmmo;
    public GameObject[] gunList;
    public AudioSource gunAudio;
    public bool isReloading;
    public RaycastHit hit;
    public Text currAmountText;
    public Text looseAmountText;
    public Text gunName;
    public Animator anim;
    public bool isInMelee;
    public bool isSwitching;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SwitchWeapon(1));    
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void SwitchToMelee()
    {
        print("ToMelee");
        EmptyAnimation();
        DeactivateWeapons();
        isInMelee = true;
        anim.SetBool("Cleaver Equip", true);
    }

    void GetInput()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0)
        {
            anim.SetBool("Walk Weapon", true);
        }
        else
        {
            anim.SetBool("Walk Weapon",  false);
        }

        if (Input.GetButtonDown("WeaponOne") && CheckGun(0)==true)
        {
            StartCoroutine(SwitchWeapon(0));
        }

        if (Input.GetButtonDown("WeaponTwo") && CheckGun(1) == true)
        {
            StartCoroutine(SwitchWeapon(1));
        }
        if(Input.GetButtonDown("WeaponThree"))
        {
            SwitchToMelee();
        }
        if(Input.GetButtonDown("Fire1") &&  isInMelee==true && GetComponent<MeleeAttack>().isMeleeing==false && isSwitching==false)
        {
            GetComponent<MeleeAttack>().StartCoroutine("EquippedStab");
            
        }
        else if (Input.GetButton("Fire1") && shoot != null && isInMelee==false && isSwitching == false)
        {
            print("shoot");
            shoot();
        }
        if (!Input.GetButton("Fire1") && decrease!=null)
        {
            anim.SetBool("Rapid Fire",false);
            decrease();
        }

        if(Input.GetMouseButton(1) && aim !=null)
        {
            anim.SetBool("Aim", true);
        }
        else if(unAim != null)
        {
            anim.SetBool("Aim", false);
        }

        if (Input.GetButtonDown("Reload") && reload != null)
        {
            StartCoroutine(reload());
        }

        if(Input.GetButtonDown("Use"))
        {
            if(Physics.Raycast(transform.position,transform.forward, out hit, 2))
            {
                if(hit.transform.tag=="AmmoPickUp")
                {
                    hit.transform.GetComponent<AmmoPackage>().AddAmmo(gameObject);
                }
                if(hit.transform.tag=="Primary")
                {
                    print("HitPrimary");
                    if(CheckGun(0)==false)
                    {
                        print("REPLACE");
                        gunList[0].transform.parent=null;
                        gunList[0].GetComponent<Collider>().enabled=true;
                        hit.transform.position=gunList[0].transform.position;
                        gunList[0]=hit.transform.gameObject;
                        gunList[0].transform.SetParent(transform);
                        hit.transform.rotation=transform.rotation;  
                        gunList[0].GetComponent<Collider>().enabled=false;
                        DeactivateWeapons();
                        gunList[0].SetActive(true);
                        CheckWeapon(0);
                        pass();

                    }
                    else if(CheckGun(0)==true)
                    {
                        print("EMPTY");
                        if (gunList[0] != null)
                        {
                            gunList[0].SetActive(true);
                            gunList[0].transform.parent = null;
                            gunList[0].GetComponent<Collider>().enabled = true;
                        }
                        gunList[0]=hit.transform.gameObject;
                        gunList[0].transform.SetParent(transform);
                        gunList[0].GetComponent<Collider>().enabled=false;
                        DeactivateWeapons();
                        gunList[0].SetActive(true);
                        CheckWeapon(0);
                        pass();
                    }
                }
            }
        }
    }

    public IEnumerator SwitchWeapon(int i)
    {
        isSwitching=true;
        DeactivateWeapons();
        if (gunList[i] != null)
        {
            gunList[i].SetActive(true);
            CheckWeapon(i);
            print("switched weapon");
            pass();
        }
        else
        {
            ClearDelegates();
            EmptyAnimation();
            print("switched to empty");
            currAmountText.text="0";
            looseAmountText.text="0";
            gunName.text= "Unarmed";

        }
        yield return new WaitForSeconds(2f);
        isSwitching=false;

    }

    public void CheckWeapon(int i)
    {
        if(gunList[i].transform.name=="Pistol")
        {
            PlayPickUpAnim(0);
        }
        if(gunList[i].transform.name=="Shotgun")
        {
            PlayPickUpAnim(1);
        }
        if(gunList[i].transform.name=="AK47")
        {
            PlayPickUpAnim(2);
        }

    }

    public void PlayPickUpAnim(int i)
    {
        EmptyAnimation();
        if(i == 0)
        {
            
            anim.SetBool("Hgun Equip", true);
        }
        if(i == 1)
        {
            anim.SetBool("Shotgun Equip", true);
        }
        if(i == 2)
        {
            anim.SetBool("AK47 Equip", true);
        }
    }

    public void EmptyAnimation()
    {
        anim.SetBool("Hgun Equip", false);
        anim.SetBool("Shotgun Equip", false);
        anim.SetBool("AK47 Equip", false);
        anim.SetBool("Cleaver Equip", false);
        anim.SetBool("Walk Weapon", false);
    }

    public void DeactivateWeapons()
    {
        isInMelee=false;
        for(int i =0; i<gunList.Length; i++)
        {
            if(gunList[i]!=null)
            {
                gunList[i].SetActive(false);
            }
        }
    }

    bool CheckGun(int i)
    {
        if(gunList[i]!=null)
        {
            if(gunList[i].active==false)
            {
                return true;
            }
        else
            {
                return false;
            }
        }
        else
        {
            return true;
        }

    }

    public void UpdateUI(float current, float loose, string name)
    {
        currAmountText.text=current.ToString("F0");
        looseAmountText.text=loose.ToString("F0");
        gunName.text=name;
    }

    void ClearDelegates()
    {
        reload=null;
        shoot=null;
        aim=null;
        unAim=null;
        decrease=null;
        addAmmo=null;
    }

    public int ReturnActiveWeapon()
    {
        if(gunList[0]==null)
        {
            return 1;
        }
        if(gunList[0].active==true) 
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }


}
