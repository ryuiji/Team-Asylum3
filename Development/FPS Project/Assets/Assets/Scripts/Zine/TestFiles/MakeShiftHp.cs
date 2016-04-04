using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MakeShiftHp : MonoBehaviour
{
    public int hp;
    public Text text;
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
            Death();
        }
        text.text=hp.ToString();
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
