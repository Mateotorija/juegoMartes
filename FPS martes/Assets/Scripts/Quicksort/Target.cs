using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public string targetName;
    public int score;
    public Target(int score, string name)
    {
        this.score = score;
        this.targetName = name;
    }
}
