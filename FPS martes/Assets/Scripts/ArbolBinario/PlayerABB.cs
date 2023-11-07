using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerABB : MonoBehaviour
{
    [SerializeField] private ABBHighScore _abbHighscore;
    public int Points;
    void Start()
    {
        _abbHighscore.abb.IncializarArbol();
        _abbHighscore.cantidadJugadores++;
        Jugador jugador = new Jugador("jugador ", _abbHighscore.Puntaje += Points);
        _abbHighscore.abb.AgregarJugador(jugador);
    }
}
