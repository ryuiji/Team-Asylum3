using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats2 : MonoBehaviour
{
    [Header("Gameplay stats")]
    public float hp;
    public float maxHP;
    public float sanity;
    public float maxSanity;
    public float moveSpeed;
    public float regenSpeed;
    public float regenAmount;
    private float allowedRegen;
    public float regenWait;
    private bool mayRegen;
    public bool isGettingExecuted;

    [Header("User Interface")]
    public Text hpText;

    [Header("Components")]
    public Animator anim;
    public AccesScript acces;
    public QuickieController movement;

    public void Start()
    {
        hpText.text = hp.ToString("F0");
        movement.moveSpeed=moveSpeed;
    }

    public void Update()
    {
        if(mayRegen)
        {
            Regen();
        }
    }

    public void TakeDamage(int damageTaken)
    {

        mayRegen=false;
        StopCoroutine("WaitForRegen");
        hp -= damageTaken;
        if (hp <= 0)
        {
            Death();
        }
        hpText.text = hp.ToString("F0");
        allowedRegen = hp + regenAmount;
        if (allowedRegen > maxHP)
        {
            allowedRegen = maxHP;
        }
        StartCoroutine("WaitForRegen");
        print(allowedRegen);
    }

    public void Regen()
    {
        hpText.text = hp.ToString("F0");
        if (hp<allowedRegen)
        {
            hp+=regenSpeed*Time.deltaTime;
        }
    }

    public IEnumerator WaitForRegen()
    {
        yield return new WaitForSeconds(regenWait);
        mayRegen=true;
    }


    IEnumerator DeathSuicide()
    {
        GetComponent<QuickieController>().enabled = false;
        anim.SetBool("Suicide", true);
        yield return new WaitForSeconds(2.6f);
        acces.ActivateDeath = true;
    }

    void Death()
    {
        GetComponent<QuickieController>().enabled = false;
        acces.ActivateDeath = true;
    }
}
