using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador
{
    public string Nombre { get; set; }
    
    public int Puntaje { get; set; }
    
    public Jugador(string nombre, int puntaje)
    {
        Nombre = nombre;
        Puntaje = puntaje;
    }
    
}