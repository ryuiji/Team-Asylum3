using UnityEngine;
using System.Collections;

public class GroundDamage : MonoBehaviour
{
    public int damageGiven;
    public PlayerStats2 player;
    public QuickieController move;
    private bool mayGiveDamage = true;
    public float damageInterval;
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.transform.tag=="EnvDamage" && mayGiveDamage==true)
        {
            player.TakeDamage(damageGiven);
            mayGiveDamage=false;
            StartCoroutine("WaitForDamage");
        }
    }

    IEnumerator WaitForDamage()
    {
        move.moveSpeed=move.moveSpeed/2;
        yield return new WaitForSeconds(damageInterval);
        mayGiveDamage=true;
        move.moveSpeed=player.moveSpeed;
    }
}
