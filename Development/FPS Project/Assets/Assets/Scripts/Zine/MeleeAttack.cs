using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour
{
    public Gunmanage gunManage;
    public AudioClip lungeAudio;
    public AudioClip stabAudio;
    public AudioSource source;
    public RaycastHit hit;
    public float stabRange;
    public int stabDamage;
    public bool isMeleeing;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        if(Input.GetButtonDown("Melee"))
        {
            if(isMeleeing==false)
            {
                StartCoroutine("Stab");
            }
        }
    }

    public IEnumerator Stab()
    {
        isMeleeing=true;
        int activeGun = gunManage.ReturnActiveWeapon();
        gunManage.DeactivateWeapons();
        gunManage.enabled=false;
        //play animation
        source.PlayOneShot(lungeAudio);
        yield return new WaitForSeconds(lungeAudio.length);  //replace with animationImpact Time
        source.PlayOneShot(stabAudio);
        if (Physics.Raycast(transform.position,transform.forward, out hit, stabRange))
        {
            if(hit.transform.tag=="EnemyBodyPart")
            {
                hit.transform.GetComponent<EnemyBodyParts>().DoDamage(stabDamage);
            }
        }
        yield return new WaitForSeconds(lungeAudio.length);
        gunManage.enabled=true;
        gunManage.SwitchWeapon(activeGun);
        isMeleeing=false;
    }
}
