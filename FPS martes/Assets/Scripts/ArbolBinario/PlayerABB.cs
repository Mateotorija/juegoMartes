using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerABB : MonoBehaviour
{
    [SerializeField] private ABBHighScore _abbHighscore;
    public int Points;
    // Start is called before the first frame update
    void Start()
    {
        _abbHighscore.abb.IncializarArbol();
        Jugador jugador = new Jugador("jugador ", _abbHighscore.Puntaje += Points);
        _abbHighscore.abb.AgregarJugador(jugador);
    }

    // Update is called once per frame 
    void Update()
    {
  
    }
}
