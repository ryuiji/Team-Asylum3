using UnityEngine;
using System.Collections;

public class RunnerEnemy : EnemyAbstract
{
    public AudioClip screamSound;
    public float sprintSpeed;
    public ParticleSystem hitParticle;
    public GameObject playerRCObj;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        player = GameObject.Find("Player");
        playerRCObj = GameObject.Find("Player RCOBJ");
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
                print("Distance");
                if (CheckLineOfSight() == true)
                {
                    print("Engaged");
                    Aggro();
                }
            }
        }
        else if (aggrod == true)
        {
            agent.SetDestination(player.transform.position);
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
                isAttacking=false;
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
        StartCoroutine("Charge");
    }

    public IEnumerator Charge()
    {
        agent.speed=0;
        audioSource.PlayOneShot(screamSound);
        yield return new WaitForSeconds(0.1f);
        agent.speed=sprintSpeed;
    }

    public override IEnumerator Attack()
    {
    	hitParticle.Play();
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
        yield return new WaitForSeconds(0.1f);  //anim length
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
        Debug.DrawLine(transform.position,player.transform.position, Color.red);
        if (Physics.Linecast(transform.position, playerRCObj.transform.position, out hit))
        {
            print(hit.transform.name);
            if (hit.transform.tag == "PlayerPart")
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
