using UnityEngine;
using System.Collections;

public abstract class EnemyAbstract : MonoBehaviour 
{
	public int health;
	public int damage;
    public float timeBetweenAttacks;
	public float moveSpeed;
	public bool lineOfSight;
	public float lengthOfSight;
    public bool aggrod;
    public float attackRange;
	public NavMeshAgent agent;
    public GameObject player;
    public RaycastHit hit;
    public bool isAttacking;
    public AudioSource audioSource;
    public AudioClip hitSound;

    public abstract void CheckForPlayer();
    public abstract bool CheckLineOfSight();
	public abstract void Aggro();
	public abstract void DeAggro();
	public abstract void Chase();
	public abstract void Roam();
	public abstract IEnumerator Attack();
	public abstract IEnumerator AttackCoolDown();
	public abstract void TakeDamage(int damage);
	public abstract IEnumerator Death();
}
