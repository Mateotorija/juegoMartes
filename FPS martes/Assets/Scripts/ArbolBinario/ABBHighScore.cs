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
    void Start()
    {
        cantidadJugadores++;
        
    }
    // Update is called once per frame
    void Update()
    {
        List<Jugador> jugadoresOrdenados = abb.Quicksort();
        Debug.Log(jugadoresOrdenados.Count);
    }


    public void MostrarPuntajes()
    {
        string puntajesTexto = "";
        List<Jugador> jugadoresOrdenados = abb.Quicksort();

        for (int i = 0; i < jugadoresOrdenados.Count; i++)
        {
            jugadoresOrdenados[i].Puntaje += _playerABB.Points;
            puntajesTexto +="\n" + (i + 1) + "*Lugar*" + jugadoresOrdenados[i].Nombre + "-Puntaje:" + jugadoresOrdenados[i].Puntaje +"\n";
        }
        puntajesText.text = puntajesTexto;
    }
}
