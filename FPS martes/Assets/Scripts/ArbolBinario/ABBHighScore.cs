using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ABBHighScore : MonoBehaviour
{
    public ABB abb = new ABB();
    [SerializeField] TMP_Text puntajesText;
    [SerializeField] public int cantidadJugadores;
    [SerializeField] private Score _score;
    [SerializeField] private PlayerABB _playerABB;
    public int Puntaje;
    // Start is called before the first frame update
    void Start()
    {
        cantidadJugadores++;
        
    }

    // Update is called once per frame
    void Update()
    {
        List<Jugador> jugadoresOrdenados = abb.ObtenerJugadoresEnOrden();
        Debug.Log(jugadoresOrdenados.Count);
    }

    //public void GenerarPuntajes()
    //{
    //    abb.IncializarArbol();

    //    for(int i = 1; i <= cantidadJugadores; i++)
    //    {
    //        Jugador jugador = new Jugador("jugador " + i, Puntaje);
    //        abb.AgregarJugador(jugador);
    //    }
    //    MostrarPuntajes();
    //}

    public void MostrarPuntajes()
    {
        string puntajesTexto = "";
        List<Jugador> jugadoresOrdenados = abb.ObtenerJugadoresEnOrden();

        for (int i = 0; i < jugadoresOrdenados.Count; i++)
        {
            jugadoresOrdenados[i].Puntaje += _playerABB.Points;
            puntajesTexto +="\n" + (i + 1) + "*Lugar*" + jugadoresOrdenados[i].Nombre + "-Puntaje:" + jugadoresOrdenados[i].Puntaje +"\n";
        }
        puntajesText.text = puntajesTexto;
    }

    //public void Click()
    //{
    //    GenerarPuntajes();
    //}
}
