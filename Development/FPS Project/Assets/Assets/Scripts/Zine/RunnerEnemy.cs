using UnityEngine;
using System.Collections;

public class RunnerEnemy : EnemyAbstract
{
    public AudioClip screamSound;
    public float sprintSpeed;
    public ParticleSystem hitParticle;
    public GameObject playerRCObj;
    public Animator anim;
    public PlayerStats2 playStats;
    public GameObject mainCam;
    public bool playerIsDead;
    void Start()
    {
        playStats = player.GetComponent<PlayerStats2>();
        anim=GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        player = GameObject.Find("Player");
        playerRCObj = GameObject.Find("Player RCOBJ");
    }

    void Update()
    {
        if (!playerIsDead)
        {
            CheckForPlayer();
        }

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
        anim.SetBool("Detect Enemy", true);
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
        anim.SetBool("Run", true);
    }

    public override IEnumerator Attack()
    {
        transform.LookAt(player.transform);
        hitParticle.Play();
        if(playStats.hp<damage)
        {
            playerIsDead = true;
            agent.speed=0;
            agent.Stop();
            player.GetComponent<QuickieController>().enabled=false;
            player.transform.LookAt(this.transform);
            anim.SetTrigger("Grab");
            yield return new WaitForSeconds(1f);
            audioSource.PlayOneShot(hitSound);
            anim.SetBool("Run", false);
            anim.SetBool("Detect Enemy", false);
            aggrod = false;
            playStats.TakeDamage((int) playStats.hp);
            anim.SetBool("Cry scene",true);
            playStats.enabled=false;
            yield break;
        }
        else
        {
            anim.SetTrigger("Attack01");
        }
        playStats.TakeDamage(damage);
        audioSource.PlayOneShot(hitSound);
        StartCoroutine("AttackCoolDown");
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
        anim.SetBool("Detect Enemy", false);
        aggrod = false;
        agent.Stop();
    }

    public override IEnumerator Death()
    {
        agent.Stop();
        GetComponent<Collider>().enabled=false;
        GetComponent<smileyDeath>().ActivateDeath=true;
        this.enabled=false;
        yield return new WaitForSeconds(2f);  //anim length
    }

    public override void Roam()
    {
        //NYI
    }


    public override void TakeDamage(int damage)
    {
        anim.SetTrigger("Hit Heavy DMG");
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
