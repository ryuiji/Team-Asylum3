using UnityEngine;
using System.Collections;
public enum BodyPart
{
    Head,
    Body,
    Arm,
    Leg,
}
public class EnemyBodyParts : MonoBehaviour
{
    public BodyPart partHit;
    public GameObject particle;
    public void DoDamage(int damage)
    {
        switch (partHit)
        {
            case BodyPart.Head:
                print("HitHead");
                damage = damage * 2;
                break;
            case BodyPart.Body:
                print("HitBody");
                break;
            case BodyPart.Arm:
                print("HitArm");
                damage = damage / 2;
                break;
            case BodyPart.Leg:
                print("HitLeg");
                damage = damage / 2;
                break;
        }
        SendMessageUpwards("TakeDamage", damage);
        Instantiate(particle,transform.position,particle.transform.rotation);
    }
}
