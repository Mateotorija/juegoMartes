using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ABBTDA
{
    Jugador Raiz();
    ABBTDA HijoIzq();
    ABBTDA HijoDer();
    bool ArbolVacio();
    void IncializarArbol();
    void AgregarJugador(Jugador jugador);
    void EliminarJugador(int puntaje);
    Jugador JugadorConMayorPuntaje();
    Jugador JugadorConMenorPuntaje();
    void ObtenerJugadoresEnOrden(Node nodo, List<Jugador> jugadores);
}
