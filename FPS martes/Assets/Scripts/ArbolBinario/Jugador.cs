using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Jugador
{
    public string Nombre;

    public int Puntaje;
    public Jugador(string nombre, int puntaje)
    {
        Nombre = nombre;
        Puntaje = puntaje;
    }
}