using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public int score;

    public Jugador Jugador { get; set; }
    public Node left { get; set; }
    public Node right { get; set; }

    public Node(Jugador jugador)
    {
        Jugador = jugador;
        left = null;
        right = null;
    }

}
