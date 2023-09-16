using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ColaBalasTF : ColaTDA
{
    #region Cola vieja
    //int[] ColaBalas; // arreglo en donde se guarda la informacion
    //    int indice; // variable entera en donde se guarda la cantidad de elementos que se tienen guardados

    //    public void InicializarCola()
    //    {
    //    ColaBalas = new int[100];
    //        indice = 0;
    //    }

    //    public void Acolar(GameObject x)
    //    {
    //        for (int i = indice - 1; i >= 0; i--)
    //        {
    //        ColaBalas[i + 1] = ColaBalas[i];
    //        }
    //    //ColaBalas[0] = x;

    //        indice++;
    //    }
    //    public void Desacolar()
    //    {
    //        indice--;
    //    }

    //    public bool ColaVacia()
    //    {
    //        return (indice == 0);
    //    }

    //    public int Primero()
    //    {
    //        return ColaBalas[indice - 1];
    //    }
    #endregion

    int _indice;
    private Queue colaBalas = new Queue();
    public void Acolar(GameObject GameObject)
    {
        //for (int i = _indice - 1; i >= 0; i--)
        //{
        //    colaBalas[i + 1] = colaBalas[i];
        //}
        colaBalas.Enqueue(GameObject);
        //ColaBalas[0] = x;

        _indice++;
    }
    public void Desacolar(GameObject LastBullet)
    {
        if (colaBalas.Count == 0)
        {
            throw new System.Exception("la cola esta vacia");
        }
        colaBalas.Dequeue();
        _indice--;
    }

    public bool ColaVacia()
    {
        return (_indice == 0);
    }

    public object Primero()
    {
        if (colaBalas.Count == 0)
        {
            throw new System.Exception("la cola esta vacia");
        }
        return colaBalas.Peek();
    }
}

