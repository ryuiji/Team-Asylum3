using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MakeShiftHp : MonoBehaviour
{
    public int hp;
    public Text text;
    public AccesScript acces;
    public CharacterController cc;
    public Animator anim;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(500);
        }
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
        GetComponent<QuickieController>().enabled=false;
        anim.SetBool("Suicide", true);
        yield return new WaitForSeconds(2.6f);
        acces.ActivateDeath=true;
    }
}
