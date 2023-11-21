using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public List<Score2> scores;

    public ScoreData()
    {
        scores = new List<Score2>();
    }
}
