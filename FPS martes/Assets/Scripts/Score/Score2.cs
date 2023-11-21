using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score2
{
    public string name;
    public int score;
    public Score2(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
