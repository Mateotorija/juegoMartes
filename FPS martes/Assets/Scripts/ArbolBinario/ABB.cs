using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABB : ABBTDA
{
    private Node raiz;

    public bool ArbolVacio()
    {
        return raiz == null;
    }

    public Jugador Raiz()
    {
        if (raiz == null)
        {
            Debug.Log("raiz vacia");
        }
        return raiz.Jugador;

    }

    public ABBTDA HijoDer()
    {
        if (raiz == null)
        {
            Debug.Log("raiz vacia");
        }
        ABB hijoDer = new ABB();
        hijoDer.raiz = raiz.right;
        return hijoDer;
    }

    public ABBTDA HijoIzq()
    {
        if (raiz == null)
        {
            Debug.Log("raiz vacia");
        }
        ABB hijoIzq = new ABB();
        hijoIzq.raiz = raiz.left;
        return hijoIzq;
    }

    public void IncializarArbol()
    {
        raiz = null;
    }

    public void AgregarJugador(Jugador jugador)
    {
        raiz = AgregarJugador(raiz, jugador);
    }

    private Node AgregarJugador(Node nodo, Jugador jugador)
    {
        if (nodo == null)
        {
            return new Node(jugador);
        }
        if(jugador.Puntaje < nodo.Jugador.Puntaje)
        {
            nodo.left = AgregarJugador(nodo.left, jugador);
        }
        else if (jugador.Puntaje > nodo.Jugador.Puntaje)
        {
           nodo.right = AgregarJugador(nodo.right, jugador);
        }
        return nodo;
    }

    public void EliminarJugador(int puntaje)
    {
        raiz = EliminarJugador(raiz, puntaje);
    }

    private Node EliminarJugador(Node nodo, int puntaje)
    {
        if (nodo == null)
        {
            return nodo;
        }
        if (puntaje < nodo.Jugador.Puntaje)
        {
            nodo.left = EliminarJugador(nodo.left, puntaje);
        }
        else if (puntaje > nodo.Jugador.Puntaje)
        {
            nodo.right = EliminarJugador(nodo.right, puntaje);
        }
        else
        {
            if (nodo.left == null)
            {
                return nodo.right;
            }
            else if (nodo.right == null)
            {
                return nodo.left;
            }

            nodo.Jugador = JugadorConMayorPuntaje(nodo.right);
            nodo.right = EliminarJugador(nodo.right, nodo.Jugador.Puntaje);
        }
        return nodo;
    }

    public Jugador JugadorConMayorPuntaje()
    {
        if (raiz == null)
        {
            Debug.Log("raiz vacia");
        }
        return JugadorConMayorPuntaje(raiz);
    }

    private Jugador JugadorConMayorPuntaje (Node nodo)
    {
        if (nodo.right == null)
        {
            return nodo.Jugador;
        }
        return JugadorConMayorPuntaje(nodo.right);
    }

    public Jugador JugadorConMenorPuntaje()
    {
        if (raiz == null)
        {
            Debug.Log("raiz vacia");
        }
        return JugadorConMenorPuntaje(raiz);
    }

    private Jugador JugadorConMenorPuntaje(Node nodo)
    {
        if (nodo.left == null)
        {
            return nodo.Jugador;
        }
        return JugadorConMayorPuntaje(nodo.left);
    }

    public List<Jugador> ObtenerJugadoresEnOrden()
    {
        List<Jugador> jugadoresEnOrden = new List<Jugador>();
        ObtenerJugadoresEnOrden(raiz, jugadoresEnOrden);
        return jugadoresEnOrden;
    }

    public void ObtenerJugadoresEnOrden(Node nodo, List<Jugador> jugadores)
    {
        if(nodo != null)
        {
            ObtenerJugadoresEnOrden(nodo.left, jugadores);
            jugadores.Add(nodo.Jugador);
            ObtenerJugadoresEnOrden(nodo.right, jugadores);
        }
    }
    public void LoadPlayerFromList(List<Jugador> jugadores)
    {
        foreach (Jugador jugador in jugadores)
            AgregarJugador(jugador);
    }
}