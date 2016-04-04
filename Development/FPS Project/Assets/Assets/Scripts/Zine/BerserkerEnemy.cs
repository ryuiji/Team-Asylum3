using UnityEngine;
using System.Collections;
using System;

public class BerserkerEnemy : EnemyAbstract
{
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed=moveSpeed;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        CheckForPlayer();
    }

    public override void CheckForPlayer()
    {
        if (aggrod == false)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < lengthOfSight)
            {
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
        aggrod = true;
        agent.SetDestination(player.transform.position);
        agent.Resume();
    }

    public override IEnumerator Attack()
    {
        player.GetComponent<MakeShiftHp>().TakeDamage(damage);
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
        //play anim
        yield return new WaitForSeconds(1f);  //anim length
        Destroy(this.gameObject);
    }

    public override void Roam()
    {
        //NYI
    }


    public override void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine("Death");
        }
    }

    public override bool CheckLineOfSight()
    {
        if (Physics.Linecast(transform.position, player.transform.position, out hit))
        {
            if (hit.transform.tag == "Player")
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
