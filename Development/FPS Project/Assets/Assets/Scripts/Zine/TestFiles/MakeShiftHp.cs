using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MakeShiftHp : MonoBehaviour
{
    public int hp;
    public Text text;
    public AccesScript acces;
    public CharacterController cc;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damageTaken)
    {
        hp-=damageTaken;
        if(hp<=0)
        {
            StartCoroutine(Death());
        }
        text.text=hp.ToString();
    }

    IEnumerator Death()
    {
        GetComponent<PlayerController>().enabled=false;
        Destroy(cc);
        yield return new WaitForSeconds(0.1f);
        acces.ActivateDeath=true;
    }
}
