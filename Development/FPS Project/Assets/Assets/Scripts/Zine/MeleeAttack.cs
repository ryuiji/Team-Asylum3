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
    public Animator anim;
    // Use this for initialization
    void Start()
    {

    }



    public IEnumerator EquippedStab()
    {
        anim.SetTrigger("Attack Weapon");
        isMeleeing = true;
        //play animation
        source.PlayOneShot(lungeAudio);
        yield return new WaitForSeconds(lungeAudio.length);  //replace with animationImpact Time
        source.PlayOneShot(stabAudio);
        if (Physics.Raycast(transform.position, transform.forward, out hit, stabRange))
        {
            if (hit.transform.tag == "EnemyBodyPart")
            {
                hit.transform.GetComponent<EnemyBodyParts>().DoDamage(stabDamage);
            }
        }
        yield return new WaitForSeconds(lungeAudio.length);
        isMeleeing = false;
    }
}
