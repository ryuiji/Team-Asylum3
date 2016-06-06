using UnityEngine;
using System.Collections;

public class Bottle2 : MonoBehaviour
{
    [Range(1, 3)]
    public int bottleNumber;
    public Puzzle puzzle;
    public void UseBottle()
    {
        puzzle.Bottle(bottleNumber);
        Destroy(this.gameObject);
    }
}
