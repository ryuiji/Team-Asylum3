using UnityEngine;
using System.Collections;

public class Bottle2 : MonoBehaviour
{
    public int bottleNumber;
    [Range(0,2)]
    public Puzzle puzzle;
    public void UseBottle()
    {
        puzzle.Bottle(bottleNumber);
    }
}
