using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public List<Jugador> scores;

    public ScoreData()
    {
        scores = new List<Jugador>();
    }
}
