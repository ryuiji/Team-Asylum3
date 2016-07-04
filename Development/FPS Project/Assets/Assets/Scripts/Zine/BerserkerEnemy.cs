using UnityEngine;
using System.Collections;
using System;

public class BerserkerEnemy : EnemyAbstract
{
    public Animator anim;
    public PlayerStats2 playStats;
    public PBragdollController ragdoll;
    public AudioClip[] attackSounds;
    public AudioClip deathSound;
    public AudioClip aggroSound;
    public AudioSource pigSound;
    public AudioClip playerHit;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed=moveSpeed;
    }

    void Update()
    {
        CheckForPlayer();
    }

    public override void CheckForPlayer()
    {
        if (aggrod == false)
        {
            print("no aggro");
            if (Vector3.Distance(transform.position, player.transform.position) < lengthOfSight)
            {
                print("close");
                if (CheckLineOfSight() == true)
                {
                    print("Engaged");
                    Aggro();
                }
            }
        }
        else if (aggrod == true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                if (isAttacking == false)
                {
                    StartCoroutine("Attack");
                }
                agent.Stop();
            }
            if (Vector3.Distance(transform.position, player.transform.position) > attackRange && Vector3.Distance(transform.position, player.transform.position) < lengthOfSight)
            {
                StopCoroutine("Attack");
                agent.SetDestination(player.transform.position);
                agent.Resume();
            }
            if (Vector3.Distance(transform.position, player.transform.position) > lengthOfSight)
            {
                DeAggro();
            }
        }

    }

    public override void Aggro()
    {
        pigSound.PlayOneShot(aggroSound);
        anim.SetBool("Run",true);
        aggrod = true;
        agent.SetDestination(player.transform.position);
        agent.Resume();
    }

    public override IEnumerator Attack()
    {
        pigSound.PlayOneShot(playerHit);
        pigSound.PlayOneShot(attackSounds[UnityEngine.Random.Range(0,attackSounds.Length)]);
        anim.SetTrigger("Attack01");
        playStats.TakeDamage(damage);
        audioSource.PlayOneShot(hitSound);
        StartCoroutine("AttackCoolDown");
        return null;
    }

    public override IEnumerator AttackCoolDown()
    {
        isAttacking=true;
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacking = false;
    }

    public override void Chase()
    {
        //play walk anim
    }

    public override void DeAggro()
    {
        aggrod = false;
        agent.Stop();
    }

    public override IEnumerator Death()
    {
        GetComponent<Collider>().enabled=false;
        pigSound.PlayOneShot(deathSound);
        ragdoll.isDead=true;
        yield return null;
        DeAggro();
        this.enabled=false;
    }

    public override void Roam()
    {
        //NYI
    }


    public override void TakeDamage(int damage)
    {
        anim.SetTrigger("Hit01");
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine("Death");
        }
    }

    public override bool CheckLineOfSight()
    {
        Debug.DrawLine(transform.position, player.transform.position, Color.red);
        if (Physics.Linecast(transform.position, player.transform.position, out hit))
        {
            print(hit.transform.name);
            if (hit.transform.tag == "Player" || hit.transform.tag == "PlayerPart")
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
            return false;
        }
    }
}
